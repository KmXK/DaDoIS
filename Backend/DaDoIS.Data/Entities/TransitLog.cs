namespace DaDoIS.Data.Entities;

public class TransitLog
{
    public Guid Id { get; set; }
    public virtual BankAccount? Source { get; set; }
    public Guid? SourceId { get; set; }
    public virtual BankAccount? Target { get; set; }
    public Guid? TargetId { get; set; }
    public required double Amount { get; set; }
    public required DateTime Date { get; set; }
}