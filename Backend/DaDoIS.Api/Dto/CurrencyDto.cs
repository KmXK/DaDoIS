namespace DaDoIS.Api.Dto;

[GraphQLName("Currency")]
public record CurrencyDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
}