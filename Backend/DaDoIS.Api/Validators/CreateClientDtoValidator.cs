using DaDoIS.Data;
using FluentValidation;

namespace DaDoIS.Api.Validators;

public class CreateClientDtoValidator : AbstractValidator<CreateClientDto>
{
    public CreateClientDtoValidator(AppDbContext db)
    {
        RuleFor(x => x.FirstName).NotEmpty().Matches("[А-Яа-я]");
        RuleFor(x => x.LastName).NotEmpty().Matches("[А-Яа-я]");
        RuleFor(x => x.Patronymic).NotEmpty().Matches("[А-Яа-я]");
        RuleFor(x => x.BirthDate).NotEmpty().LessThan(DateTime.Now);
        RuleFor(x => x.Gender).NotEmpty().IsInEnum();

        RuleFor(x => x.PassportSeries).Matches("[A-Z]{2}");
        RuleFor(x => x.PassportNumber).Matches("[0-9]{7}");
        RuleFor(x => x.PassportSeries + x.PassportNumber).Must((passportCode) =>
            !db.Clients.Any(c => passportCode.Equals(c.PassportSeries + c.PassportNumber)));

        RuleFor(x => x.PassportIssuer).NotEmpty();
        RuleFor(x => x.PassportIssueDate).NotEmpty().LessThan(DateTime.Now);
        RuleFor(x => x.IdentificationNumber).Matches("[0-9A-Z]{14}").Must((id) => !db.Clients.Any(c => c.IdentificationNumber == id));
        RuleFor(x => x.BirthPlace).NotEmpty();
        RuleFor(x => x.LivingCityId).NotEmpty().Must((id) => db.Cities.Any(c => c.Id == id));
        RuleFor(x => x.LivingAddress).NotEmpty();

        RuleFor(x => x.HomePhoneNumber).Matches(@"\+?[0-9 ]").When(x => x.HomePhoneNumber != null);
        RuleFor(x => x.PhoneNumber).Matches(@"\+?[0-9 ]").When(x => x.PhoneNumber != null);
        RuleFor(x => x.Email).EmailAddress().When(x => x.Email != null);
        RuleFor(x => x.WorkPlace);
        RuleFor(x => x.Position);

        RuleFor(x => x.RegistrationCityId).NotEmpty().Must((id) => db.Cities.Any(c => c.Id == id));
        RuleFor(x => x.RegistrationAddress).NotEmpty();
        RuleFor(x => x.MaritalStatus).NotEmpty().IsInEnum();
        RuleFor(x => x.CitizenshipId).NotEmpty().Must((id) => db.Citizenship.Any(c => c.Id == id));
        RuleFor(x => x.DisabilityGroup).NotEmpty().IsInEnum();
        RuleFor(x => x.IsRetired).NotEmpty();

        RuleFor(x => x.Salary); // Может быть любой валютой, поэтому не только цифры

        RuleFor(x => x.IsLiableForMilitaryService).NotEmpty();
    }
}