using DaDoIS.Data;
using FluentValidation;

namespace DaDoIS.Api.Validators;

/// <summary>
/// Валидатор для сущности "Клиент"
/// </summary>
public class CreateClientDtoValidator : AbstractValidator<CreateClientDto>
{
    /// <summary>
    /// Настройка валидатора для сущности "Клиент"
    /// </summary>
    /// <param name="db"></param>
    public CreateClientDtoValidator(AppDbContext db)
    {
        RuleFor(x => x.FirstName).NotEmpty().Matches("^[А-Я][а-я]+$");
        RuleFor(x => x.LastName).NotEmpty().Matches("^[А-Я][а-я]+$");
        RuleFor(x => x.Patronymic).NotEmpty().Matches("^[А-Я][а-я]+$");
        RuleFor(x => x.BirthDate).NotEmpty().LessThan(DateTime.Now);
        RuleFor(x => x.Gender).IsInEnum();

        RuleFor(x => x.PassportSeries).Matches("^[A-Z]{2}$");
        RuleFor(x => x.PassportNumber).Matches("^[0-9]{7}$");
        // RuleFor(x => x.PassportSeries + x.PassportNumber).Must((passportCode) =>
        //     db.Clients.FirstOrDefault(c => passportCode.Equals(c.PassportSeries + c.PassportNumber)))
        //     .WithName("Passport")
        //     .WithMessage("Passport must be unique.");

        RuleFor(x => x.PassportIssuer).NotEmpty();
        RuleFor(x => x.PassportIssueDate).NotEmpty().LessThan(DateTime.Now);
        // RuleFor(x => x.IdentificationNumber).Matches("^[0-9A-Z]{14}$").Must((id) => !db.Clients.Any(c => c.IdentificationNumber == id));
        RuleFor(x => x.BirthPlace).NotEmpty();
        RuleFor(x => x.LivingCityId).Must((id) => db.Cities.Any(c => c.Id == id));
        RuleFor(x => x.LivingAddress).NotEmpty();

        RuleFor(x => x.HomePhoneNumber).Matches(@"^\+?[0-9]{7}$").When(x => !string.IsNullOrWhiteSpace(x.HomePhoneNumber));
        RuleFor(x => x.PhoneNumber).Matches(@"^\+?[0-9]{12}$").When(x => !string.IsNullOrWhiteSpace(x.PhoneNumber));
        RuleFor(x => x.Email).EmailAddress().When(x => !string.IsNullOrWhiteSpace(x.Email));
        RuleFor(x => x.WorkPlace);
        RuleFor(x => x.Position);

        RuleFor(x => x.RegistrationCityId).Must((id) => db.Cities.Any(c => c.Id == id));
        RuleFor(x => x.RegistrationAddress).NotEmpty();
        RuleFor(x => x.MaritalStatus).IsInEnum();
        RuleFor(x => x.CitizenshipId).Must((id) => db.Citizenship.Any(c => c.Id == id));
        RuleFor(x => x.DisabilityGroup).IsInEnum();
        RuleFor(x => x.IsRetired);

        RuleFor(x => x.Salary).Must(x => x >= 0); // Может быть любой валютой, поэтому не только цифры

        RuleFor(x => x.IsLiableForMilitaryService);
    }
}
