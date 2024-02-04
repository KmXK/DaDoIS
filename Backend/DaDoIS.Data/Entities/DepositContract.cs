using System.ComponentModel.DataAnnotations.Schema;

namespace DaDoIS.Data.Entities;

public class DepositContract
{
    public int Id { get; set; }
    public required string Number { get; set; }
    public virtual required Client Client { get; set; }
    public required Guid ClientId { get; set; }
    public virtual required Deposit Deposit { get; set; }
    public required int DepositId { get; set; }
    public required DateTime DateBegin { get; set; }
    public required DateTime DateEnd { get; set; }
    [Column(TypeName = "money")]
    public required double Amount { get; set; }
}