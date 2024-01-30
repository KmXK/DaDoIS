using FluentValidation;

namespace DaDoIS.Api.Validators;

public class CreateCityDtoValidator : AbstractValidator<CreateCityDto>
{
    public CreateCityDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}