namespace DaDoIS.Data.Entities;

public class BankAccount
{
    public Guid Id { get; set; }
    public required double Debit { get; set; }
    public required double Credit { get; set; }
    public required AccountType Type { get; set; }
    public virtual required Currency Currency { get; set; }
    public required int CurrencyId { get; set; }
}