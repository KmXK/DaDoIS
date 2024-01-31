using FluentValidation;

namespace DaDoIS.Api.Validators;

/// <summary>
/// Валидатор для сущности "Город"
/// </summary>
public class CreateCityDtoValidator : AbstractValidator<CreateCityDto>
{
    /// <summary>
    /// Настройка валидатора для сущности "Город"
    /// </summary>
    public CreateCityDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}