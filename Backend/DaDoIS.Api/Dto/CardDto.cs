namespace DaDoIS.Api.Dto;

public class CardDto
{
    public int Id { get; set; }
    public required string CardNumber { get; set; }
    public required int Pin { get; set; }
    public required BankAccountDto BankAccount { get; set; }
    public required ClientDto Client { get; set; }
    public bool IsBlocked { get; set; }
}

public class CardInfoDto
{
    public double Amount { get; set; }
    public required CardDto Card { get; set; }
    public List<TransitLogDto>? TransitLogs { get; set; }
}