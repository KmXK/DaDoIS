using System.ComponentModel.DataAnnotations.Schema;

namespace DaDoIS.Data.Entities;

public class CreditContract
{
    public int Id { get; set; }
    public required string Number { get; set; }
    public virtual required Client Client { get; set; }
    public required Guid ClientId { get; set; }
    public virtual required Credit Credit { get; set; }
    public required int CreditId { get; set; }
    public required DateTime DateBegin { get; set; }
    public required DateTime DateEnd { get; set; }
    public required bool IsActive { get; set; }
    public required int DaysToEnd { get; set; }
    public virtual required List<BankAccount> BankAccounts { get; set; }

    [Column(TypeName = "money")]
    public required double Amount { get; set; }
}