using FluentValidation;

namespace DaDoIS.Api.Validators;

public class CreateClientDtoValidator : AbstractValidator<CreateClientDto>
{
    public CreateClientDtoValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Patronymic).NotEmpty();
        RuleFor(x => x.BirthDate).NotEmpty().LessThan(DateTime.Now);
        RuleFor(x => x.Gender).NotEmpty().InclusiveBetween(0, 2);
        RuleFor(x => x.PassportSeries).Matches("[A-Z]{2}");
        RuleFor(x => x.PassportNumber).Matches("[0-9]{7}");
        RuleFor(x => x.PassportIssuer).NotEmpty();
        RuleFor(x => x.PassportIssueDate).NotEmpty().LessThan(DateTime.Now);
        RuleFor(x => x.IdentificationNumber).Matches("[0-9A-Z]{14}");
        RuleFor(x => x.BirthPlace).NotEmpty();
        RuleFor(x => x.LivingCityId).NotEmpty();
        RuleFor(x => x.LivingAddress).NotEmpty();

        RuleFor(x => x.RegistrationCityId).NotEmpty(); // добавить проверку в базе
        RuleFor(x => x.RegistrationAddress).NotEmpty();
        RuleFor(x => x.MaritalStatus).NotEmpty().InclusiveBetween(0, 3);
        RuleFor(x => x.CitizenshipId).NotEmpty(); // добавить проверку в базе
        RuleFor(x => x.DisabilityGroup).NotEmpty().InclusiveBetween(0, 3);
        RuleFor(x => x.IsRetired).NotEmpty();

        RuleFor(x => x.IsLiableForMilitaryService).NotEmpty();
    }
}