using System.ComponentModel.DataAnnotations;

namespace DaDoIS.Models;

public class Client
{
    [Key]
    public Guid Id { get; init; }

    [Required(ErrorMessage = "First Name is required.")]
    public required string FirstName { get; init; }

    [Required]
    public required string LastName { get; init; }

    [Required]
    public required string Patronymic { get; init; }

    public DateTime BirthDate { get; init; }

    public GenderType Gender { get; init; }

    [Required]
    [StringLength(2, MinimumLength = 2, ErrorMessage = "Passport series must be 2 characters long.")]
    public required string PassportSeries { get; init; }

    [Required]
    [StringLength(7, MinimumLength = 7, ErrorMessage = "Passport number must be 7 characters long.")]
    public required string PassportNumber { get; init; }

    [Required]
    public required string PassportIssuer { get; init; }

    [Required]
    public DateTime PassportIssueDate { get; init; }

    [Required]
    public required string IdentificationNumber { get; init; }

    [Required]
    public required string BirthPlace { get; init; }

    [Required]
    public required City LivingCity { get; init; }

    [Required]
    public required string LivingAddress { get; init; }

    [Phone]
    public string? HomePhoneNumber { get; init; }

    [Phone]
    public string? PhoneNumber { get; init; }

    [EmailAddress]
    public string? Email { get; init; }

    public string? WorkPlace { get; init; }

    public string? Position { get; init; }

    [Required]
    public required City RegistrationCity { get; init; }

    [Required]
    public required string RegistrationAddress { get; init; }

    [Required]
    public MaritalStatus MaritalStatus { get; init; }

    [Required]
    public required Citizenship Citizenship { get; init; }

    public DisabilityGroup DisabilityGroup { get; init; }

    public bool IsRetired { get; init; }

    [DataType(DataType.Currency)]
    public decimal? Salary { get; init; }

    public bool IsLiableForMilitaryService { get; init; }
}
