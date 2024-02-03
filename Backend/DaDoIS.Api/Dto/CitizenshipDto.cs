namespace DaDoIS.Api;

[GraphQLName("Citizenship")]
public record CitizenshipDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
}
