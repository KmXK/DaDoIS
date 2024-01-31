using AutoMapper;
using DaDoIS.Data.Entities;

namespace DaDoIS.Api.Configuration;

/// <summary>
/// Mapping configuring class
/// </summary>
public class MapperProfile : Profile
{
    /// <summary>
    /// Mapping configuring class constructor
    /// </summary>
    public MapperProfile()
    {
        CreateMap<City, CityDto>();
        CreateMap<CreateCityDto, City>();

        CreateMap<Citizenship, CitizenshipDto>();
        CreateMap<CreateCitizenshipDto, Citizenship>();

        CreateMap<Client, ClientDto>();
        CreateMap<CreateClientDto, Client>();
        CreateMap<ClientDto, CreateClientDto>();
    }
}