namespace DaDoIS.Data.Entities;

public class Deposit
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Period { get; set; }
    public double Interest { get; set; }
    public bool IsRevocable { get; set; }
}