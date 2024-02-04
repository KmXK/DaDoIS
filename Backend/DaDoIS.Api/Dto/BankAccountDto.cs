using DaDoIS.Data.Entities;

namespace DaDoIS.Api.Dto;

[GraphQLName("BankAccount")]
public record BankAccountDto
{
    public Guid Id { get; set; }
    public required double Debit { get; set; }
    public required double Credit { get; set; }
    public required AccountType Type { get; set; }
    public virtual required CurrencyDto Currency { get; set; }
}