using DaDoIS.Api.Dto;
using FluentValidation;

namespace DaDoIS.Api.Validators;

public class DepositValidator : AbstractValidator<CreateDepositDto>
{
    public DepositValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Period).NotEmpty();
        RuleFor(x => x.Interest).NotEmpty();
        RuleFor(x => x.IsRevocable).NotNull();
    }
}