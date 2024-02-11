using AutoMapper;
using AutoMapper.QueryableExtensions;
using DaDoIS.Api.Dto;
using DaDoIS.Data.Entities;

namespace DaDoIS.Api.Configuration;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Client, ClientDto>();
        CreateMap<City, CityDto>();
        CreateMap<Citizenship, CitizenshipDto>();

        CreateMap<Currency, CurrencyDto>();
        CreateMap<BankAccount, BankAccountDto>();
        CreateMap<TransitLog, TransitLogDto>();
        CreateMap<Deposit, DepositDto>();
        CreateMap<DepositContract, DepositContractDto>();
        CreateMap<Credit, CreditDto>();
        CreateMap<CreditContract, CreditContractDto>();
        CreateMap<Card, CardDto>();


        CreateMap<CreateClientDto, Client>();
        CreateMap<UpdateClientDto, Client>();
        CreateMap<CreateDepositDto, Deposit>();
        CreateMap<CreateDepositContractDto, DepositContract>();
        CreateMap<CreateCreditDto, Credit>();
        CreateMap<CreateCreditContractDto, CreditContract>();
    }
}

public static class MapperExtensions
{
    private static readonly MapperConfiguration _mapperConfig = new(cfg =>
    {
        cfg.CreateProjection<Client, ClientDto>();
        cfg.CreateProjection<City, CityDto>();
        cfg.CreateProjection<Citizenship, CitizenshipDto>();
        cfg.CreateProjection<Currency, CurrencyDto>();
        cfg.CreateProjection<BankAccount, BankAccountDto>();
        cfg.CreateProjection<TransitLog, TransitLogDto>();
        cfg.CreateProjection<Deposit, DepositDto>();
        cfg.CreateProjection<DepositContract, DepositContractDto>();
        cfg.CreateProjection<Credit, CreditDto>();
        cfg.CreateProjection<CreditContract, CreditContractDto>();
        cfg.CreateProjection<Card, CardDto>();
    });

    public static IQueryable<T> ProjectTo<T>(this IQueryable data) =>
        data.ProjectTo<T>(_mapperConfig);
}