using DaDoIS.Api.Dto;
using FluentValidation;

namespace DaDoIS.Api.Validators;

public class CreditValidator : AbstractValidator<CreateCreditDto>
{
    public CreditValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Period).NotEmpty();
        RuleFor(x => x.Interest).NotEmpty();
        RuleFor(x => x.IsAnnuity).NotNull();
    }
}