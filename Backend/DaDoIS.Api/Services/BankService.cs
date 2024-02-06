using DaDoIS.Api.Dto;
using DaDoIS.Api.Exceptions;
using DaDoIS.Data;
using DaDoIS.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DaDoIS.Api.Services;

public class BankService(AppDbContext db)
{
    public DepositContract CreateDepositContract(CreateDepositContractDto dto)
    {
        var client = db.Clients.Find(dto.ClientId);
        var deposit = db.Deposits.Find(dto.DepositId);

        var depositAccount = db.BankAccounts.Add(new()
        {
            Debit = 0,
            Credit = 0,
            AccountType = AccountType.Passive,
            TypeOfAccount = TypeOfAccount.Deposit,
            Currency = deposit!.Currency,
            CurrencyId = deposit!.CurrencyId,
        }).Entity;
        db.SaveChanges();

        var percentAccount = db.BankAccounts.Add(new()
        {
            Debit = 0,
            Credit = 0,
            AccountType = AccountType.Passive,
            TypeOfAccount = TypeOfAccount.Percent,
            Currency = deposit!.Currency,
            CurrencyId = deposit!.CurrencyId,
        }).Entity;
        db.SaveChanges();

        var depositContract = db.DepositContracts.Add(new()
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
        }).Entity;
        db.SaveChanges();

        var money = dto.Amount * deposit.Currency.ExchangeRate;
        var cash = db.BankAccounts.First(x => x.TypeOfAccount == TypeOfAccount.Cash);
        var main = db.BankAccounts.First(x => x.TypeOfAccount == TypeOfAccount.Main);

        TransferMoney(money, null, cash);
        TransferMoney(money, cash, depositAccount);
        TransferMoney(money, depositAccount, main);

        return depositContract;
    }

    public void CloseDepositContract(int contractId)
    {
        var contract = db.DepositContracts.Find(contractId) ?? throw new NotFoundException("DepositContract");
        contract.IsActive = false;
        db.SaveChanges();

        var money = contract.Amount * contract.Deposit.Currency.ExchangeRate;
        var cashAccount = db.BankAccounts.First(x => x.TypeOfAccount == TypeOfAccount.Cash);
        var mainAccount = db.BankAccounts.First(x => x.TypeOfAccount == TypeOfAccount.Main);

        var depositAccount = contract.BankAccounts.First(x => x.TypeOfAccount == TypeOfAccount.Deposit);
        var percentAccount = contract.BankAccounts.First(x => x.TypeOfAccount == TypeOfAccount.Percent);

        if (contract.Deposit.IsRevocable)
        {
            TransferMoney(money, mainAccount, depositAccount);
            TransferMoney(money, depositAccount, cashAccount);
            TransferMoney(money, cashAccount, null);
        }
        else
        {
            TransferPercents(contract, contract.Deposit.Period);

            TransferMoney(money, mainAccount, depositAccount);
            TransferMoney(money, depositAccount, cashAccount);
            TransferMoney(money, cashAccount, null);
        }
    }

    public void TransferPercents(DepositContract contract, int days)
    {
        var money = contract.Amount * contract.Deposit.Currency.ExchangeRate;
        var percentMoney = contract.Deposit.Interest / 12.0 * (days / 30);

        var cashAccount = db.BankAccounts.First(x => x.TypeOfAccount == TypeOfAccount.Cash);
        var mainAccount = db.BankAccounts.First(x => x.TypeOfAccount == TypeOfAccount.Main);
        var depositAccount = contract.BankAccounts.First(x => x.TypeOfAccount == TypeOfAccount.Deposit);
        var percentAccount = contract.BankAccounts.First(x => x.TypeOfAccount == TypeOfAccount.Percent);

        TransferMoney(percentMoney, mainAccount, percentAccount);
        TransferMoney(percentMoney, percentAccount, cashAccount);
        TransferMoney(percentMoney, cashAccount, null);
    }

    public void AddToAccount(BankAccount? account, double money)
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
            db.SaveChanges();
        }
    }

    public void RemoveFromAccount(BankAccount? account, double money)
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
            db.SaveChanges();
        }
    }

    public void TransferMoney(double money, BankAccount? from, BankAccount? to)
    {
        RemoveFromAccount(from, money);
        AddToAccount(to, money);
        db.TransitLogs.Add(new()
        {
            SourceId = from?.Id,
            Source = from,
            TargetId = to?.Id,
            Target = to,
            Date = DateTime.Now,
            Amount = money
        });
        db.SaveChanges();
    }

    public async Task CloseBankDay(int daysCount)
    {
        for (int i = 0; i < daysCount; i++) await CloseBankDay();
    }

    public async Task CloseBankDay()
    {
        await db.DepositContracts
            .Where(c => c.IsActive)
            .ForEachAsync(c => c.DaysToEnd = -1);

        await db.DepositContracts
            .Where(c => c.Deposit.IsRevocable)
            .Where(c => c.DaysToEnd % 30 == 0)
            .ForEachAsync(c => TransferPercents(c, 30));

        await db.DepositContracts
            .Where(c => c.DaysToEnd == 0)
            .ForEachAsync(c => CloseDepositContract(c.Id));
    }
}