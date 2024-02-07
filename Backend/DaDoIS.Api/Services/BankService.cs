using DaDoIS.Api.Dto;
using DaDoIS.Api.Exceptions;
using DaDoIS.Data;
using DaDoIS.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DaDoIS.Api.Services;

public class BankService(AppDbContext db)
{
    public async Task<DepositContract> CreateDepositContract(CreateDepositContractDto dto)
    {
        var client = await db.Clients.FindAsync(dto.ClientId);
        var deposit = await db.Deposits.FindAsync(dto.DepositId);

        var depositAccount = (await db.BankAccounts.AddAsync(new()
        {
            Debit = 0,
            Credit = 0,
            AccountType = AccountType.Passive,
            TypeOfAccount = TypeOfAccount.Deposit,
            Currency = deposit!.Currency,
            CurrencyId = deposit!.CurrencyId,
        })).Entity;
        await db.SaveChangesAsync();

        var percentAccount = (await db.BankAccounts.AddAsync(new()
        {
            Debit = 0,
            Credit = 0,
            AccountType = AccountType.Passive,
            TypeOfAccount = TypeOfAccount.Percent,
            Currency = deposit!.Currency,
            CurrencyId = deposit!.CurrencyId,
        })).Entity;
        await db.SaveChangesAsync();

        var depositContract = (await db.DepositContracts.AddAsync(new()
        {
            Number = dto.Number,
            Client = client!,
            ClientId = dto.ClientId,
            Deposit = deposit,
            DepositId = dto.DepositId,
            DateBegin = DateTime.Now,
            DateEnd = DateTime.Now.AddDays(deposit.Period),
            IsActive = true,
            DaysToEnd = deposit.Period,
            Amount = dto.Amount,
            BankAccounts = [depositAccount, percentAccount]
        })).Entity;
        await db.SaveChangesAsync();

        var money = dto.Amount * deposit.Currency.ExchangeRate;
        var cash = await db.BankAccounts.FirstAsync(x => x.TypeOfAccount == TypeOfAccount.Cash);
        var main = await db.BankAccounts.FirstAsync(x => x.TypeOfAccount == TypeOfAccount.Main);

        await TransferMoney(money, null, cash);
        await TransferMoney(money, cash, depositAccount);
        await TransferMoney(money, depositAccount, main);

        return depositContract;
    }

    public async Task CloseDepositContract(int contractId)
    {
        var contract = await db.DepositContracts.FindAsync(contractId) ?? throw new NotFoundException("DepositContract");

        var money = contract.Amount * contract.Deposit.Currency.ExchangeRate;
        var cashAccount = await db.BankAccounts.FirstAsync(x => x.TypeOfAccount == TypeOfAccount.Cash);
        var mainAccount = await db.BankAccounts.FirstAsync(x => x.TypeOfAccount == TypeOfAccount.Main);

        var percentAccount = contract.BankAccounts.First(x => x.TypeOfAccount == TypeOfAccount.Percent);
        var depositAccount = contract.BankAccounts.First(x => x.TypeOfAccount == TypeOfAccount.Deposit);

        await TransferMoney(money, mainAccount, depositAccount);
        await TransferMoney(money, depositAccount, cashAccount);
        await TransferMoney(money, cashAccount, null);

        contract.IsActive = false;
        await db.SaveChangesAsync();
    }

    public async Task TransferPercents(DepositContract contract, int days)
    {
        var money = contract.Amount * contract.Deposit.Currency.ExchangeRate;
        var percentMoney = contract.Deposit.Interest / 12.0 * (days / 30) * money;

        var cashAccount = await db.BankAccounts.FirstAsync(x => x.TypeOfAccount == TypeOfAccount.Cash);
        var mainAccount = await db.BankAccounts.FirstAsync(x => x.TypeOfAccount == TypeOfAccount.Main);
        var depositAccount = contract.BankAccounts.First(x => x.TypeOfAccount == TypeOfAccount.Deposit);
        var percentAccount = contract.BankAccounts.First(x => x.TypeOfAccount == TypeOfAccount.Percent);

        await TransferMoney(percentMoney, mainAccount, percentAccount);
        await TransferMoney(percentMoney, percentAccount, cashAccount);
        await TransferMoney(percentMoney, cashAccount, null);
    }

    public async Task TransferMoney(double money, BankAccount? from, BankAccount? to)
    {
        await RemoveFromAccount(from, money);
        await AddToAccount(to, money);
        await db.TransitLogs.AddAsync(new()
        {
            SourceId = from?.Id,
            Source = from,
            TargetId = to?.Id,
            Target = to,
            Date = DateTime.Now,
            Amount = money
        });
        await db.SaveChangesAsync();
    }

    public async Task AddToAccount(BankAccount? account, double money)
    {
        if (account is not null)
        {
            money /= account.Currency.ExchangeRate;
            switch (account.AccountType)
            {
                case AccountType.Active:
                    account.Debit += money;
                    break;
                case AccountType.Passive:
                    account.Credit += money;
                    break;
            }
            await db.SaveChangesAsync();
        }
    }

    public async Task RemoveFromAccount(BankAccount? account, double money)
    {
        if (account is not null)
        {
            money /= account.Currency.ExchangeRate;
            switch (account.AccountType)
            {
                case AccountType.Active:
                    account.Credit += money;
                    break;
                case AccountType.Passive:
                    account.Debit += money;
                    break;
            }
            await db.SaveChangesAsync();
        }
    }

    public async Task CloseBankDay(int daysCount)
    {
        var contracts = await db.DepositContracts.Where(c => c.IsActive).ToListAsync();

        foreach (var contract in contracts)
        {
            if (contract.Deposit.IsRevocable)
            {
                var percentsCount = 0;
                var startDay = contract.DaysToEnd;
                contract.DaysToEnd -= daysCount;
                var endDay = contract.DaysToEnd;
                endDay = endDay < 0 ? 0 : endDay;

                for (int i = contract.DaysToEnd - 1; i >= contract.DaysToEnd - daysCount; i--)
                    if (i % 30 == 0) percentsCount++;

                for (int i = 0; i < percentsCount; i++)
                    await TransferPercents(contract, 30);

                if (endDay == 0)
                {
                    await TransferPercents(contract, 30);
                    await CloseDepositContract(contract.Id);
                }

            }
            else
            {
                contract.DaysToEnd -= daysCount;
                if (contract.DaysToEnd <= 0)
                {
                    contract.DaysToEnd = 0;
                    await TransferPercents(contract, contract.Deposit.Period);
                    await CloseDepositContract(contract.Id);
                }
            }
        }
    }

    public async Task CloseBankDay()
    {
        await db.DepositContracts
            .Where(c => c.IsActive)
            .ForEachAsync(c => c.DaysToEnd--);
        await db.SaveChangesAsync();

        var depositContracts = await db.DepositContracts
            .Where(c => c.Deposit.IsRevocable &&
                        c.DaysToEnd != c.Deposit.Period &&
                        c.DaysToEnd % 30 == 0).ToListAsync();
        foreach (var contract in depositContracts)
            await TransferPercents(contract, 30);

        depositContracts = await db.DepositContracts
            .Where(c => c.DaysToEnd == 0).ToListAsync();
        foreach (var contract in depositContracts)
            await CloseDepositContract(contract.Id);
    }
}