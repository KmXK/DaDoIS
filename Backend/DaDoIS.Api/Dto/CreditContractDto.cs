namespace DaDoIS.Api.Dto;

[GraphQLName("CreditContract")]
public record CreditContractDto
{
    public required int Id { get; set; }
    public required string Number { get; set; }
    public required ClientDto Client { get; set; }
    public required CreditDto Credit { get; set; }
    public required DateTime DateBegin { get; set; }
    public required DateTime DateEnd { get; set; }
    public required bool IsActive { get; set; }
    public required int DaysToEnd { get; set; }
    public required double Amount { get; set; }
    public required List<BankAccountDto> BankAccounts { get; set; }
}

[GraphQLName("CreateCreditContract")]
public record CreateCreditContractDto
{
    public required string Number { get; set; }
    public required Guid ClientId { get; set; }
    public required int CreditId { get; set; }
    public required double Amount { get; set; }
}