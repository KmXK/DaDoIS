namespace DaDoIS.Data.Entities;

public class TransitLog
{
    public Guid Id { get; set; }
    public virtual required BankAccount Source { get; set; }
    public required Guid SourceId { get; set; }
    public virtual required BankAccount Target { get; set; }
    public required Guid TargetId { get; set; }
    public required double Amount { get; set; }
    public required DateTime Date { get; set; }
}