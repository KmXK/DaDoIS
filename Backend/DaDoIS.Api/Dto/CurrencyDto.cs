namespace DaDoIS.Api.Dto;

[GraphQLName("Currency")]
public record CurrencyDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
}