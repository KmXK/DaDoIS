using AutoMapper.QueryableExtensions;
using DaDoIS.Api.Configuration;
using DaDoIS.Api.Dto;
using DaDoIS.Data;

namespace DaDoIS.Api.Queries;

public class Queries
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<CityDto> Cities([Service] AppDbContext db) =>
        db.Cities.AsQueryable().ProjectTo<CityDto>();

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<ClientDto> Clients([Service] AppDbContext db) =>
        db.Clients.AsQueryable().ProjectTo<ClientDto>();

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<CitizenshipDto> Citizenship([Service] AppDbContext db) =>
        db.Citizenship.AsQueryable().ProjectTo<CitizenshipDto>();

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<CurrencyDto> Currencies([Service] AppDbContext db) =>
        db.Currencies.AsQueryable().ProjectTo<CurrencyDto>();

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<DepositDto> Deposits([Service] AppDbContext db) =>
        db.Deposits.AsQueryable().ProjectTo<DepositDto>();
}