namespace DaDoIS.Api;

public record CityDto
{
    public int Id;
    public required string Name;
}

public record CreateCityDto
{
    public required string Name;
}

public record DeleteCityDto
{
    public int Id;
}


