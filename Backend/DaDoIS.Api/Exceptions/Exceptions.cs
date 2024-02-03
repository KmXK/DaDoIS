namespace DaDoIS.Api.Exceptions;

public class NotFoundException(string Member) : Exception
{
    public override string ToString() => $"{Member} not found";
}