using AutoMapper;
using DaDoIS.Data.Entities;

namespace DaDoIS.Api.Properties;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<City, CityDto>();
        CreateMap<CreateCityDto, City>();

        CreateMap<Citizenship, CitizenshipDto>();
        CreateMap<CreateCitizenshipDto, Citizenship>();

        CreateMap<Client, ClientDto>();
        CreateMap<CreateClientDto, Client>();
    }
}