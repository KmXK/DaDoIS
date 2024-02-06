namespace DaDoIS.Api.Dto;

[GraphQLName("City")]
public record CityDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
}