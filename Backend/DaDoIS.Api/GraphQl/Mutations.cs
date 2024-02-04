using AutoMapper;
using DaDoIS.Api.Exceptions;
using DaDoIS.Api.Dto;
using DaDoIS.Data;
using DaDoIS.Data.Entities;
using FluentValidation;

namespace DaDoIS.Api.GraphQl;

public class Mutations
{
    public ClientDto CreateClient([GraphQLName("client")] CreateClientDto dto,
                                  [Service] IValidator<CreateClientDto> validator,
                                  [Service] IMapper mapper,
                                  [Service] AppDbContext db)
    {
        validator.ValidateAndThrow(dto);
        var client = db.Clients.Add(mapper.Map<Client>(dto)).Entity;
        db.SaveChanges();
        return mapper.Map<ClientDto>(client);
    }

    public ClientDto? PutClient([GraphQLName("client")] UpdateClientDto dto,
                                [Service] IValidator<UpdateClientDto> validator,
                                [Service] IMapper mapper,
                                [Service] AppDbContext db)
    {
        validator.ValidateAndThrow(dto);
        var client = db.Clients.Find(dto.Id) ?? throw new NotFoundException("Client");
        mapper.Map(dto, client);
        db.SaveChanges();
        return mapper.Map<ClientDto>(client);
    }

    public bool DeleteClient(Guid id, [Service] AppDbContext db)
    {
        var client = db.Clients.Find(id) ?? throw new NotFoundException("Client");
        db.Clients.Remove(client);
        db.SaveChanges();
        return true;
    }

    public DepositDto CreateDeposit([GraphQLName("deposit")] CreateDepositDto dto,
                                    [Service] IValidator<CreateDepositDto> validator,
                                    [Service] IMapper mapper,
                                    [Service] AppDbContext db)
    {
        validator.ValidateAndThrow(dto);
        var deposit = db.Deposits.Add(mapper.Map<Deposit>(dto)).Entity;
        db.SaveChanges();
        return mapper.Map<DepositDto>(deposit);
    }

    public bool DeleteDeposit(int id, [Service] AppDbContext db)
    {
        var deposit = db.Deposits.Find(id) ?? throw new NotFoundException("Deposit");
        db.Deposits.Remove(deposit);
        db.SaveChanges();
        return true;
    }

}