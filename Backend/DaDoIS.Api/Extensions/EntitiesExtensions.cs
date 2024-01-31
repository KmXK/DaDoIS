using DaDoIS.Data.Entities;

namespace DaDoIS.Api.Extensions;

public static class EntitiesExtensions
{
    public static ClientDto ToDto(this Client client)
    {
        return new ClientDto
        {
            Id = client.Id,
            FirstName = client.FirstName,
            LastName = client.LastName,
            Patronymic = client.Patronymic,
            BirthDate = client.BirthDate,
            Gender = client.Gender,
            PassportSeries = client.PassportSeries,
            PassportNumber = client.PassportNumber,
            PassportIssuer = client.PassportIssuer,
            PassportIssueDate = client.PassportIssueDate,
            IdentificationNumber = client.IdentificationNumber,
            BirthPlace = client.BirthPlace,
            LivingCityId = client.LivingCityId,
            LivingAddress = client.LivingAddress,
            HomePhoneNumber = client.HomePhoneNumber,
            PhoneNumber = client.PhoneNumber,
            Email = client.Email,
            WorkPlace = client.WorkPlace,
            Position = client.Position,
            RegistrationCityId = client.RegistrationCityId,
            RegistrationAddress = client.RegistrationAddress,
            MaritalStatus = client.MaritalStatus,
            CitizenshipId = client.CitizenshipId,
            DisabilityGroup = client.DisabilityGroup,
            IsRetired = client.IsRetired,
            Salary = client.Salary,
            IsLiableForMilitaryService = client.IsLiableForMilitaryService,
        };
    }
}