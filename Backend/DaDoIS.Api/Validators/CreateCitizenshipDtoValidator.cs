using FluentValidation;

namespace DaDoIS.Api.Validators;

/// <summary>
/// Валидатор для сущности "Гражданство"
/// </summary>
public class CreateCitizenshipDtoValidator : AbstractValidator<CreateCitizenshipDto>
{
    /// <summary>
    /// Настройка валидатора для сущности "Гражданство"
    /// </summary>
    public CreateCitizenshipDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}