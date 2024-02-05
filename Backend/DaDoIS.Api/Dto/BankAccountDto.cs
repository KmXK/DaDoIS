using DaDoIS.Data.Entities;

namespace DaDoIS.Api.Dto;

[GraphQLName("BankAccount")]
public record BankAccountDto
{
    public required Guid Id { get; set; }
    public required double Debit { get; set; }
    public required double Credit { get; set; }
    public required AccountType AccountType { get; set; }
    public required TypeOfAccount TypeOfAccount { get; set; }
    public required CurrencyDto Currency { get; set; }
    public DepositContractDto? DepositContract { get; set; }
}