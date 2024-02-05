namespace DaDoIS.Api.Dto;

[GraphQLName("DepositContract")]
public record DepositContractDto
{
    public required int Id { get; set; }
    public required string Number { get; set; }
    public required ClientDto Client { get; set; }
    public required DepositDto Deposit { get; set; }
    public required DateTime DateBegin { get; set; }
    public required DateTime DateEnd { get; set; }
    public required bool IsActive { get; set; }
    public required int DaysToEnd { get; set; }
    public required double Amount { get; set; }
    public required List<BankAccountDto> BankAccounts { get; set; }
}

[GraphQLName("CreateDepositContract")]
public record CreateDepositContractDto
{
    public required string Number { get; set; }
    public required Guid ClientId { get; set; }
    public required int DepositId { get; set; }
    public required double Amount { get; set; }
}