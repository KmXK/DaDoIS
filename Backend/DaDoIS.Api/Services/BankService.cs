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
            TypeOfAccount = TypeOfAccount.DepositPercent,
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

        var cash = await db.BankAccounts.FirstAsync(x => x.TypeOfAccount == TypeOfAccount.Cash);
        var main = await db.BankAccounts.FirstAsync(x => x.TypeOfAccount == TypeOfAccount.Main);
        var percentAccount = contract.BankAccounts.First(x => x.TypeOfAccount == TypeOfAccount.DepositPercent);
        var depositAccount = contract.BankAccounts.First(x => x.TypeOfAccount == TypeOfAccount.Deposit);

        var money = contract.Amount * contract.Deposit.Currency.ExchangeRate;

        await TransferMoney(money, main, depositAccount);
        await TransferMoney(money, depositAccount, cash);
        await TransferMoney(money, cash, null);

        contract.IsActive = false;
        await db.SaveChangesAsync();
    }

    public async Task<CreditContract> CreateCreditContract(CreateCreditContractDto dto)
    {
        var client = await db.Clients.FindAsync(dto.ClientId);
        var credit = await db.Credits.FindAsync(dto.CreditId);

        var creditAccount = (await db.BankAccounts.AddAsync(new()
        {
            Debit = 0,
            Credit = 0,
            AccountType = AccountType.Active,
            TypeOfAccount = TypeOfAccount.Credit,
            Currency = credit!.Currency,
            CurrencyId = credit!.CurrencyId,
        })).Entity;
        await db.SaveChangesAsync();

        var percentAccount = (await db.BankAccounts.AddAsync(new()
        {
            Debit = 0,
            Credit = 0,
            AccountType = AccountType.Active,
            TypeOfAccount = TypeOfAccount.CreditPercent,
            Currency = credit!.Currency,
            CurrencyId = credit!.CurrencyId,
        })).Entity;
        await db.SaveChangesAsync();

        var creditContract = (await db.CreditContracts.AddAsync(new()
        {
            Number = dto.Number,
            Client = client!,
            ClientId = dto.ClientId,
            Credit = credit,
            CreditId = dto.CreditId,
            DateBegin = DateTime.Now,
            DateEnd = DateTime.Now.AddDays(credit.Period),
            IsActive = true,
            DaysToEnd = credit.Period,
            Amount = dto.Amount,
            BankAccounts = [creditAccount, percentAccount]
        })).Entity;
        await db.SaveChangesAsync();

        var money = dto.Amount * credit.Currency.ExchangeRate;
        var cash = await db.BankAccounts.FirstAsync(x => x.TypeOfAccount == TypeOfAccount.Cash);
        var main = await db.BankAccounts.FirstAsync(x => x.TypeOfAccount == TypeOfAccount.Main);

        await TransferMoney(money, main, creditAccount);
        //await TransferMoney(money, creditAccount, cash);
        //await TransferMoney(money, cash, null);

        return creditContract;
    }

    public async Task CloseCreditContract(int contractId)
    {
        var contract = await db.CreditContracts.FindAsync(contractId) ?? throw new NotFoundException("CreditContract");

        if (!contract.Credit.IsAnnuity)
        {
            var cash = await db.BankAccounts.FirstAsync(x => x.TypeOfAccount == TypeOfAccount.Cash);
            var main = await db.BankAccounts.FirstAsync(x => x.TypeOfAccount == TypeOfAccount.Main);
            var percentAccount = contract.BankAccounts.First(x => x.TypeOfAccount == TypeOfAccount.CreditPercent);
            var creditAccount = contract.BankAccounts.First(x => x.TypeOfAccount == TypeOfAccount.Credit);

            var money = contract.Amount * contract.Credit.Currency.ExchangeRate;

            //await TransferMoney(money, null, cash);
            //await TransferMoney(money, cash, creditAccount);
            await TransferMoney(money, creditAccount, main);
        }

        contract.IsActive = false;
        await db.SaveChangesAsync();
    }

    public async Task TransferDepositPercents(DepositContract contract, int days)
    {
        var money = contract.Amount * contract.Deposit.Currency.ExchangeRate;
        var percentMoney = contract.Deposit.Interest / 12.0 * (days / 30) * money;

        var cash = await db.BankAccounts.FirstAsync(x => x.TypeOfAccount == TypeOfAccount.Cash);
        var main = await db.BankAccounts.FirstAsync(x => x.TypeOfAccount == TypeOfAccount.Main);
        var depositAccount = contract.BankAccounts.First(x => x.TypeOfAccount == TypeOfAccount.Deposit);
        var percentAccount = contract.BankAccounts.First(x => x.TypeOfAccount == TypeOfAccount.DepositPercent);

        await TransferMoney(percentMoney, main, percentAccount);
        await TransferMoney(percentMoney, percentAccount, cash);
        await TransferMoney(percentMoney, cash, null);
    }

    public async Task TransferCreditPercents(CreditContract contract)
    {
        double money;

        if (contract.Credit.IsAnnuity)
        {
            var S = contract.Amount;
            var P = contract.Credit.Interest;
            var N = contract.Credit.Period / 30;
            money = S * P / 12 * Math.Pow(1 + P / 12, N) / (Math.Pow(1 + P / 12, N) - 1);
        }
        else
        {
            money = contract.Amount / 12 * contract.Credit.Interest;
        }

        money *= contract.Credit.Currency.ExchangeRate;

        var cash = await db.BankAccounts.FirstAsync(x => x.TypeOfAccount == TypeOfAccount.Cash);
        var main = await db.BankAccounts.FirstAsync(x => x.TypeOfAccount == TypeOfAccount.Main);
        var creditAccount = contract.BankAccounts.First(x => x.TypeOfAccount == TypeOfAccount.Credit);
        var percentAccount = contract.BankAccounts.First(x => x.TypeOfAccount == TypeOfAccount.CreditPercent);

        await TransferMoney(money, percentAccount, main);
        await TransferMoney(money, null, cash);
        await TransferMoney(money, cash, percentAccount);
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
        var depositContracts = await db.DepositContracts.Where(c => c.IsActive).ToListAsync();
        foreach (var contract in depositContracts)
        {
            if (contract.Deposit.IsRevocable)
            {
                var startDay = contract.DaysToEnd;
                contract.DaysToEnd -= daysCount;
                var endDay = contract.DaysToEnd;
                endDay = endDay < 0 ? 0 : endDay;

                for (int i = startDay - 1; i >= endDay; i--)
                    if (i % 30 == 0)
                        await TransferDepositPercents(contract, 30);

                if (endDay == 0)
                {
                    contract.DaysToEnd = 0;
                    await CloseDepositContract(contract.Id);
                }
            }
            else
            {
                contract.DaysToEnd -= daysCount;
                if (contract.DaysToEnd <= 0)
                {
                    contract.DaysToEnd = 0;
                    await TransferDepositPercents(contract, contract.Deposit.Period);
                    await CloseDepositContract(contract.Id);
                }
            }
        }

        var creditContracts = await db.CreditContracts.Where(c => c.IsActive).ToListAsync();
        foreach (var contract in creditContracts)
        {
            var startDay = contract.DaysToEnd;
            contract.DaysToEnd -= daysCount;
            var endDay = contract.DaysToEnd;
            endDay = endDay < 0 ? 0 : endDay;

            for (int i = startDay - 1; i >= endDay; i--)
                if (i % 30 == 0)
                    await TransferCreditPercents(contract);

            if (endDay == 0)
            {
                contract.DaysToEnd = 0;
                await CloseCreditContract(contract.Id);
            }
        }
    }
}