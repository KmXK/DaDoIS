namespace DaDoIS.Api.Dto;

[GraphQLName("TransitLog")]
public class TransitLogDto
{
    public required Guid Id { get; set; }
    public virtual BankAccountDto? Source { get; set; }
    public virtual BankAccountDto? Target { get; set; }
    public required double Amount { get; set; }
    public required DateTime Date { get; set; }
}