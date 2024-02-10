using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DaDoIS.Data.Entities;

public class Client
{
    public Guid Id { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Patronymic { get; init; }
    public DateTime BirthDate { get; init; }
    public GenderType Gender { get; init; }
    [Unicode(false)]
    [StringLength(2, MinimumLength = 2)]
    public required string PassportSeries { get; init; }
    [Unicode(false)]
    [StringLength(7, MinimumLength = 7)]
    public required string PassportNumber { get; init; }
    public required string PassportIssuer { get; init; }
    public DateTime PassportIssueDate { get; init; }
    [Unicode(false)]
    public required string IdentificationNumber { get; init; }
    public required string BirthPlace { get; init; }
    public virtual required City LivingCity { get; init; }
    public required int LivingCityId { get; init; }
    public required string LivingAddress { get; init; }
    [Phone]
    public string? HomePhoneNumber { get; init; }
    [Phone]
    public string? PhoneNumber { get; init; }
    [EmailAddress]
    public string? Email { get; init; }
    public string? WorkPlace { get; init; }
    public string? Position { get; init; }
    public virtual required City RegistrationCity { get; init; }
    public required int RegistrationCityId { get; init; }
    public required string RegistrationAddress { get; init; }
    public MaritalStatus MaritalStatus { get; init; }
    public virtual required Citizenship Citizenship { get; init; }
    public required int CitizenshipId { get; init; }
    public DisabilityGroup DisabilityGroup { get; init; }
    public bool IsRetired { get; init; }
    [Column(TypeName = "money")]
    public double? Salary { get; init; }
    public bool IsLiableForMilitaryService { get; init; }
    public virtual List<DepositContract>? DepositContracts { get; init; }
    public virtual List<CreditContract>? CreditContracts { get; init; }
}