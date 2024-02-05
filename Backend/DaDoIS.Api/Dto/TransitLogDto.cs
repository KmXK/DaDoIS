namespace DaDoIS.Api.Dto;

[GraphQLName("TransitLog")]
public class TransitLogDto
{
    public Guid Id { get; set; }
    public virtual required BankAccountDto Source { get; set; }
    public virtual required BankAccountDto Target { get; set; }
    public required double Amount { get; set; }
    public required DateTime Date { get; set; }
}