namespace DaDoIS.Api.Dto;

[GraphQLName("Credit")]
public record CreditDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required int Period { get; set; }
    public required double Interest { get; set; }
    public required bool IsAnnuity { get; set; }
    public required CurrencyDto Currency { get; set; }
}

[GraphQLName("CreateCredit")]
public record CreateCreditDto
{
    public required string Name { get; set; }
    public required int Period { get; set; }
    public required double Interest { get; set; }
    public required bool IsAnnuity { get; set; }
    public required int CurrencyId { get; set; }
}