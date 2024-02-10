using DaDoIS.Api.Exceptions;
using FluentValidation;

namespace DaDoIS.Api.GraphQl;

public class ErrorFilter : IErrorFilter
{
    public IError OnError(IError error)
    {
        return error.Exception switch
        {
            ValidationException vex => error
                .RemoveCode()
                .RemoveException()
                .RemoveLocations()
                .RemovePath()
                .WithMessage("Validation error")
                .WithExtensions(
                    vex.Errors.ToDictionary(
                        e => e.PropertyName.ToLower(),
                        e => (object?)new Dictionary<string, object>()
                        {
                            ["PropertyName"] = e.PropertyName,
                            ["Message"] = e.ErrorMessage
                        })),
            NotFoundException nex => error
                .RemoveCode()
                .RemoveException()
                .RemoveLocations()
                .RemovePath()
                .WithMessage(nex.ToString()),
            ErrorException eex => error
                .RemoveCode()
                .RemoveException()
                .RemoveLocations()
                .RemovePath()
                .WithMessage(eex.ToString()),
            _ => error.WithException(error.Exception),
        };
    }
}