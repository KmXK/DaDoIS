namespace DaDoIS.Data.Entities;

public class BankAccount
{
    public Guid Id { get; set; }
    public required double Debit { get; set; }
    public required double Credit { get; set; }
    public required AccountType AccountType { get; set; }
    public required TypeOfAccount TypeOfAccount { get; set; }
    public virtual required Currency Currency { get; set; }
    public required int CurrencyId { get; set; }
    public virtual DepositContract? DepositContract { get; set; }
    public int? DepositContractId { get; set; }

}