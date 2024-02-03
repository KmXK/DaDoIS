using AutoMapper.QueryableExtensions;
using DaDoIS.Api.Configuration;
using DaDoIS.Data;

namespace DaDoIS.Api.Queries;

public class Queries
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<CityDto> Cities([Service] AppDbContext appDbContext) =>
        appDbContext.Cities.AsQueryable().ProjectTo<CityDto>();

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<ClientDto> Clients([Service] AppDbContext appDbContext) =>
        appDbContext.Clients.AsQueryable().ProjectTo<ClientDto>();

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<CitizenshipDto> Citizenship([Service] AppDbContext appDbContext) =>
        appDbContext.Citizenship.AsQueryable().ProjectTo<CitizenshipDto>();
}