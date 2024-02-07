using AutoMapper;
using DaDoIS.Api.Exceptions;
using DaDoIS.Api.Dto;
using DaDoIS.Data;
using DaDoIS.Data.Entities;
using FluentValidation;
using DaDoIS.Api.Services;

namespace DaDoIS.Api.GraphQl;

public class Mutations
{
    public async Task<ClientDto> CreateClient([GraphQLName("client")] CreateClientDto dto,
                                  [Service] IValidator<CreateClientDto> validator,
                                  [Service] IMapper mapper,
                                  [Service] AppDbContext db)
    {
        await validator.ValidateAndThrowAsync(dto);
        var client = (await db.Clients.AddAsync(mapper.Map<Client>(dto))).Entity;
        await db.SaveChangesAsync();
        return mapper.Map<ClientDto>(client);
    }

    public async Task<ClientDto?> PutClient([GraphQLName("client")] UpdateClientDto dto,
                                [Service] IValidator<UpdateClientDto> validator,
                                [Service] IMapper mapper,
                                [Service] AppDbContext db)
    {
        await validator.ValidateAndThrowAsync(dto);
        var client = await db.Clients.FindAsync(dto.Id) ?? throw new NotFoundException("Client");
        mapper.Map(dto, client);
        await db.SaveChangesAsync();
        return mapper.Map<ClientDto>(client);
    }

    public async Task<bool> DeleteClient(Guid id, [Service] AppDbContext db)
    {
        var client = await db.Clients.FindAsync(id) ?? throw new NotFoundException("Client");
        db.Clients.Remove(client);
        await db.SaveChangesAsync();
        return true;
    }

    public async Task<DepositDto> CreateDeposit([GraphQLName("deposit")] CreateDepositDto dto,
                                    [Service] IValidator<CreateDepositDto> validator,
                                    [Service] IMapper mapper,
                                    [Service] AppDbContext db)
    {
        await validator.ValidateAndThrowAsync(dto);
        var deposit = (await db.Deposits.AddAsync(mapper.Map<Deposit>(dto))).Entity;
        await db.SaveChangesAsync();
        return mapper.Map<DepositDto>(deposit);
    }

    public async Task<bool> DeleteDeposit(int id, [Service] AppDbContext db)
    {
        var deposit = await db.Deposits.FindAsync(id) ?? throw new NotFoundException("Deposit");
        db.Deposits.Remove(deposit);
        await db.SaveChangesAsync();
        return true;
    }

    public async Task<DepositContractDto> CreateDepositContract(
        [GraphQLName("depositContract")] CreateDepositContractDto dto,
        [Service] IValidator<CreateDepositContractDto> validator,
        [Service] IMapper mapper,
        [Service] BankService service)
    {
        await validator.ValidateAndThrowAsync(dto);
        var deposit = await service.CreateDepositContract(dto);
        return mapper.Map<DepositContractDto>(deposit);
    }

    public async Task<bool> CloseDepositContract(int id, [Service] BankService service)
    {
        await service.CloseDepositContract(id);
        return true;
    }

    public async Task<bool> CloseBankDay(int days, [Service] BankService service)
    {
        await service.CloseBankDay(days);
        return true;
    }
}