namespace DaDoIS.Data.Entities;

public class Credit
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required int Period { get; set; }
    public required double Interest { get; set; }
    public required bool IsAnnuity { get; set; }
    public virtual required Currency Currency { get; set; }
    public required int CurrencyId { get; set; }
}