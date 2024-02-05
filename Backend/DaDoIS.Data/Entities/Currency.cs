namespace DaDoIS.Data.Entities;

public class Currency
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required double ExchangeRate { get; set; }
}