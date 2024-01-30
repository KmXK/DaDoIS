using FluentValidation;

namespace DaDoIS.Api.Validators;

public class CreateCitizenshipDtoValidator : AbstractValidator<CreateCitizenshipDto>
{
    public CreateCitizenshipDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}