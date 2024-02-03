using DaDoIS.Data.Entities;

namespace DaDoIS.Api;

[GraphQLName("Client")]
public record ClientDto
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Patronymic { get; set; }
    public DateTime BirthDate { get; set; }
    public GenderType Gender { get; set; }
    public required string PassportSeries { get; set; }
    public required string PassportNumber { get; set; }
    public required string PassportIssuer { get; set; }
    public DateTime PassportIssueDate { get; set; }
    public required string IdentificationNumber { get; set; }
    public required string BirthPlace { get; set; }
    public required CityDto LivingCity { get; set; }
    public required string LivingAddress { get; set; }
    public string? HomePhoneNumber { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? WorkPlace { get; set; }
    public string? Position { get; set; }
    public required CityDto RegistrationCity { get; set; }
    public required string RegistrationAddress { get; set; }
    public MaritalStatus MaritalStatus { get; set; }
    public required CitizenshipDto Citizenship { get; set; }
    public DisabilityGroup DisabilityGroup { get; set; }
    public bool IsRetired { get; set; }
    public double? Salary { get; set; }
    public bool IsLiableForMilitaryService { get; set; }
}
public record CreateClientDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Patronymic { get; set; }
    public DateTime BirthDate { get; set; }
    public GenderType Gender { get; set; }
    public required string PassportSeries { get; set; }
    public required string PassportNumber { get; set; }
    public required string PassportIssuer { get; set; }
    public DateTime PassportIssueDate { get; set; }
    public required string IdentificationNumber { get; set; }
    public required string BirthPlace { get; set; }
    public required int LivingCityId { get; set; }
    public required string LivingAddress { get; set; }
    public string? HomePhoneNumber { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? WorkPlace { get; set; }
    public string? Position { get; set; }
    public required int RegistrationCityId { get; set; }
    public required string RegistrationAddress { get; set; }
    public MaritalStatus MaritalStatus { get; set; }
    public required int CitizenshipId { get; set; }
    public DisabilityGroup DisabilityGroup { get; set; }
    public bool IsRetired { get; set; }
    public double? Salary { get; set; }
    public bool IsLiableForMilitaryService { get; set; }
}

public record UpdateClientDto
{
    public required Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Patronymic { get; set; }
    public DateTime BirthDate { get; set; }
    public GenderType Gender { get; set; }
    public required string PassportSeries { get; set; }
    public required string PassportNumber { get; set; }
    public required string PassportIssuer { get; set; }
    public DateTime PassportIssueDate { get; set; }
    public required string IdentificationNumber { get; set; }
    public required string BirthPlace { get; set; }
    public required int LivingCityId { get; set; }
    public required string LivingAddress { get; set; }
    public string? HomePhoneNumber { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? WorkPlace { get; set; }
    public string? Position { get; set; }
    public required int RegistrationCityId { get; set; }
    public required string RegistrationAddress { get; set; }
    public MaritalStatus MaritalStatus { get; set; }
    public required int CitizenshipId { get; set; }
    public DisabilityGroup DisabilityGroup { get; set; }
    public bool IsRetired { get; set; }
    public double? Salary { get; set; }
    public bool IsLiableForMilitaryService { get; set; }
}
