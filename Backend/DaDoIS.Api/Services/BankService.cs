using DaDoIS.Api.Dto;
using DaDoIS.Data;
using DaDoIS.Data.Entities;

namespace DaDoIS.Api.Services;

public class BankService(AppDbContext db)
{
    public DepositContract? CreateDepositContract(CreateDepositContractDto dto)
    {
        var client = db.Clients.Find(dto.ClientId);
        var deposit = db.Deposits.Find(dto.DepositId);

        if (client is null || deposit is null) return null;

        var depositAccount = db.BankAccounts.Add(new()
        {
            Debit = 0,
            Credit = 0,
            AccountType = AccountType.Passive,
            TypeOfAccount = TypeOfAccount.Deposit,
            Currency = deposit.Currency,
            CurrencyId = deposit.CurrencyId,
        }).Entity;
        db.SaveChanges();

        var percentAccount = db.BankAccounts.Add(new()
        {
            Debit = 0,
            Credit = 0,
            AccountType = AccountType.Passive,
            TypeOfAccount = TypeOfAccount.Percent,
            Currency = deposit.Currency,
            CurrencyId = deposit.CurrencyId,
        }).Entity;
        db.SaveChanges();

        var depositContract = db.DepositContracts.Add(new()
        {
            Number = dto.Number,
            Client = client,
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

    public void CloseBankDay(int daysCount)
    {
        for (int i = 0; i < daysCount; i++) CloseBankDay();
    }

    public void CloseBankDay()
    {
        throw new NotImplementedException();
    }
}