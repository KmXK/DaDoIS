namespace DaDoIS.Data.Entities;

public class Card
{
    public int Id { get; set; }
    public string CardNumber => Id.ToString("0000000000000000");
    public required int Pin { get; set; }
    public Guid? Token { get; set; }
    public int Counter { get; set; }
    public bool IsBlocked { get; set; }
    public virtual required BankAccount BankAccount { get; set; }
    public required Guid BankAccountId { get; set; }
    public virtual required Client Client { get; set; }
    public required Guid ClientId { get; set; }
}