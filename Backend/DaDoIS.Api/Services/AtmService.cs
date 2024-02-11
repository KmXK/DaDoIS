using AutoMapper;
using DaDoIS.Api.Configuration;
using DaDoIS.Api.Dto;
using DaDoIS.Api.Exceptions;
using DaDoIS.Data;
using DaDoIS.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DaDoIS.Api.Services;

public class AtmService(BankService bankService, AppDbContext db, IMapper mapper)
{
    public async Task<Guid> InsertCard(string cardNumber, int pin)
    {
        var id = int.Parse(cardNumber);
        var card = await db.Cards.FindAsync(id) ?? throw new NotFoundException("Card");

        if (card.IsBlocked)
            throw new ErrorException("Card is blocked");

        if (card.Pin != pin)
        {
            card.Counter++;
            if (card.Counter == 3)
                card.IsBlocked = true;
            await db.SaveChangesAsync();
            throw new ErrorException($"Invalid Pin. There are {3 - card.Counter} attempts left{(card.Counter == 3 ? ". Card is blocked" : "")}");
        }

        var token = Guid.NewGuid();
        card.Token = token;
        card.Counter = 0;
        await db.SaveChangesAsync();

        return token;
    }

    public async Task<CardInfoDto> GetCardInfo(Guid token)
    {
        var card = await db.Cards.FirstOrDefaultAsync(c => c.Token.Equals(token)) ?? throw new NotFoundException("Card");
        return await GetCardInfo(card);
    }

    public async Task<CardInfoDto> GetCardInfo(Card card) => new()
    {
        Amount = card.BankAccount.Amount,
        Card = mapper.Map<CardDto>(card),
        TransitLogs = await db.TransitLogs
                .AsSplitQuery()
                .Where(t => t.SourceId == card.BankAccountId || t.TargetId == card.BankAccountId)
                .OrderBy(t => t.Date)
                .AsQueryable()
                .ProjectTo<TransitLogDto>()
                .ToListAsync()
    };

    public async Task<CardInfoDto> PuttingMoneyOnPhone(Guid token, double amount, Guid accountId)
    {
        var card = await db.Cards.FirstOrDefaultAsync(c => c.Token.Equals(token)) ?? throw new NotFoundException("Card");
        var phoneAccount = await db.BankAccounts.FindAsync(accountId) ?? throw new NotFoundException("Phone Account");
        if (amount > card.BankAccount.Amount)
            throw new ErrorException("Not enough money");
        await bankService.TransferMoney(amount, card.BankAccount, phoneAccount);
        return await GetCardInfo(card);
    }

    public async Task<CardInfoDto> WithdrawMoney(Guid token, double amount)
    {
        var card = await db.Cards.FirstOrDefaultAsync(c => c.Token.Equals(token)) ?? throw new NotFoundException("Card");
        var cash = await db.BankAccounts.FirstAsync(x => x.TypeOfAccount == TypeOfAccount.Cash);
        if (amount > card.BankAccount.Amount)
            throw new ErrorException("Not enough money");
        await bankService.TransferMoney(amount, card.BankAccount, cash);
        await bankService.TransferMoney(amount, cash, null);
        return await GetCardInfo(card);
    }

    public async Task<bool> GetCard(Guid token)
    {
        var card = await db.Cards.FirstOrDefaultAsync(c => c.Token.Equals(token)) ?? throw new NotFoundException("Card");
        card.Token = null;
        await db.SaveChangesAsync();
        return true;
    }


}