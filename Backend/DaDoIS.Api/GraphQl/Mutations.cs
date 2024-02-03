using AutoMapper;
using DaDoIS.Api.Exceptions;
using DaDoIS.Api.Validators;
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
}