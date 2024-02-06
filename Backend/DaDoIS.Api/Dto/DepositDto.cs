namespace DaDoIS.Api.Dto;

[GraphQLName("Deposit")]
public record DepositDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required int Period { get; set; }
    public required double Interest { get; set; }
    public required bool IsRevocable { get; set; }
    public required CurrencyDto Currency { get; set; }
}

[GraphQLName("CreateDeposit")]
public record CreateDepositDto
{
    public required string Name { get; set; }
    public required int Period { get; set; }
    public required double Interest { get; set; }
    public required bool IsRevocable { get; set; }
    public required int CurrencyId { get; set; }
}