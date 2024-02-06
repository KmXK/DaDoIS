namespace DaDoIS.Api.Dto;

[GraphQLName("Citizenship")]
public record CitizenshipDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
}
