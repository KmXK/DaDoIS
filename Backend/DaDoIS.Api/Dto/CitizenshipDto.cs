namespace DaDoIS.Api;

public record CitizenshipDto
{
    public int Id;
    public required string Name;
}

public record CreateCitizenshipDto
{
    public required string Name;
}

public record DeleteCitizenshipDto
{
    public int Id;
}
