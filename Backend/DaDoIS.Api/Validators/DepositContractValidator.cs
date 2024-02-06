using DaDoIS.Api.Dto;
using DaDoIS.Data;
using FluentValidation;

namespace DaDoIS.Api.Validators;

public class DepositContractValidator : AbstractValidator<CreateDepositContractDto>
{
    public DepositContractValidator(AppDbContext db)
    {
        RuleFor(x => x.Number).NotEmpty();
        RuleFor(x => x.DepositId).NotEmpty()
            .Must((id) => !db.Deposits.Any(d => d.Id == id))
            .WithMessage("There is no deposit with the specified number");
        RuleFor(x => x.ClientId).NotEmpty()
            .Must((id) => !db.Clients.Any(c => c.Id == id))
            .WithMessage("There is no client with the specified number");
        RuleFor(x => x.Amount).NotEmpty();
    }
}