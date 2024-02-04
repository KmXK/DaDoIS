namespace DaDoIS.Api.Dto;

[GraphQLName("Deposit")]
public class DepositDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required int Period { get; set; }
    public required double Interest { get; set; }
    public required bool IsRevocable { get; set; }
}

[GraphQLName("CreateDeposit")]
public class CreateDepositDto
{
    public required string Name { get; set; }
    public required int Period { get; set; }
    public required double Interest { get; set; }
    public required bool IsRevocable { get; set; }
}