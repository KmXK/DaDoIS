using System.ComponentModel.DataAnnotations;

namespace DaDoIS.Models;

public class City
{
    [Key]
    public int Id { get; init; }
    
    [Required]
    public required string Name { get; init; }
}
