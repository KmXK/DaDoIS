using System.ComponentModel.DataAnnotations.Schema;

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
    public virtual CreditContract? CreditContract { get; set; }
    public int? CreditContractId { get; set; }
    public virtual List<Card>? Cards { get; set; }
    [NotMapped]
    public double Amount { get => AccountType == AccountType.Active ? Debit - Credit : Credit - Debit; }
    [NotMapped]
    public string IBANNumber
    {
        get
        {
            return $"BY42BGBG{GetTypeAccountCode()}00000000{Id.ToString().ToUpper()[..8]}";
        }
    }

    public string GetTypeAccountCode()
    {
        return TypeOfAccount switch
        {
            TypeOfAccount.Main => "7327",
            TypeOfAccount.Cash => "1010",
            TypeOfAccount.Deposit => "3014",
            TypeOfAccount.DepositPercent => "3014",
            TypeOfAccount.Credit => "2400",
            TypeOfAccount.CreditPercent => "2400",
            _ => "1111",
        };
    }

}