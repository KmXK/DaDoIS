using System.ComponentModel.DataAnnotations;

namespace DaDoIS.Data.Models;

public class Citizenship
{
    [Key]
    public int Id { get; init; }

    [Required]
    public required string Name { get; init; }
}
