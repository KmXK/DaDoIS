namespace DaDoIS.Api;

public record ClientDto
{
    public Guid Id;
    public required string FirstName;
    public required string LastName;
    public required string Patronymic;
    public DateTime BirthDate;
    public int Gender;
    public required string PassportSeries;
    public required string PassportNumber;
    public required string PassportIssuer;
    public DateTime PassportIssueDate;
    public required string IdentificationNumber;
    public required string BirthPlace;
    public required int LivingCityId;
    public required string LivingAddress;
    public string? HomePhoneNumber;
    public string? PhoneNumber;
    public string? Email;
    public string? WorkPlace;
    public string? Position;
    public required int RegistrationCityId;
    public required string RegistrationAddress;
    public int MaritalStatus;
    public required int CitizenshipId;
    public int DisabilityGroup;
    public bool IsRetired;
    public double? Salary;
    public bool IsLiableForMilitaryService;
}

public record CreateClientDto
{
    public required string FirstName;
    public required string LastName;
    public required string Patronymic;
    public DateTime BirthDate;
    public int Gender;
    public required string PassportSeries;
    public required string PassportNumber;
    public required string PassportIssuer;
    public DateTime PassportIssueDate;
    public required string IdentificationNumber;
    public required string BirthPlace;
    public required int LivingCityId;
    public required string LivingAddress;
    public string? HomePhoneNumber;
    public string? PhoneNumber;
    public string? Email;
    public string? WorkPlace;
    public string? Position;
    public required int RegistrationCityId;
    public required string RegistrationAddress;
    public int MaritalStatus;
    public required int CitizenshipId;
    public int DisabilityGroup;
    public bool IsRetired;
    public double? Salary;
    public bool IsLiableForMilitaryService;
}

public record DeleteClientDto
{
    public Guid Id;
}

