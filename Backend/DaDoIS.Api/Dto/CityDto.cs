namespace DaDoIS.Api;

[GraphQLName("City")]
public record CityDto
{
    public int Id { get; init; }
    public required string Name { get; set; }
}