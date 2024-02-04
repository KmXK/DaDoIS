namespace DaDoIS.Data.Entities;

public class Deposit
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required int Period { get; set; }
    public required double Interest { get; set; }
    public required bool IsRevocable { get; set; }
}