using AutoMapper;
using AutoMapper.QueryableExtensions;
using DaDoIS.Api.Dto;
using DaDoIS.Data.Entities;

namespace DaDoIS.Api.Configuration;

public class MapperProfile : Profile
{

    public MapperProfile()
    {
        CreateMap<CreateClientDto, Client>();
        CreateMap<UpdateClientDto, Client>();
        CreateMap<CreateDepositDto, Deposit>();

        CreateMap<Client, ClientDto>();
        CreateMap<City, CityDto>();
        CreateMap<Citizenship, CitizenshipDto>();

        CreateMap<Currency, CurrencyDto>();
        CreateMap<Deposit, DepositDto>();
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
        cfg.CreateProjection<Deposit, DepositDto>();
    });

    public static IQueryable<T> ProjectTo<T>(this IQueryable data) =>
        data.ProjectTo<T>(_mapperConfig);
}