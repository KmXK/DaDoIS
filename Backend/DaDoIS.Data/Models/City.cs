using System.ComponentModel.DataAnnotations;

namespace DaDoIS.Data.Models;

public class City
{
    [Key]
    public int Id { get; init; }

    [Required]
    public required string Name { get; init; }
}
