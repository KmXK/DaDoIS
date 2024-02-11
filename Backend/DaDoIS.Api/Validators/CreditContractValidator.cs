using DaDoIS.Api.Dto;
using DaDoIS.Data;
using FluentValidation;

namespace DaDoIS.Api.Validators;

public class CreditContractValidator : AbstractValidator<CreateCreditContractDto>
{
    public CreditContractValidator(AppDbContext db)
    {
        RuleFor(x => x.Number).NotEmpty()
            .Must((num) => !db.CreditContracts.Any(d => d.Number.Equals(num)))
            .WithMessage("Number must be unique.");
        RuleFor(x => x.CreditId).NotEmpty()
            .Must((id) => db.Credits.Any(d => d.Id == id))
            .WithMessage("There is no credit with the specified number");
        RuleFor(x => x.ClientId).NotEmpty()
            .Must((id) => db.Clients.Any(c => c.Id == id))
            .WithMessage("There is no client with the specified number");
        RuleFor(x => x.Amount).NotEmpty();
    }
}