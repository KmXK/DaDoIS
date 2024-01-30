using System.ComponentModel.DataAnnotations;

namespace DaDoIS.Data.Models;

public class Citizenship
{
    public int Id { get; init; }

    public required string Name { get; init; }
}
