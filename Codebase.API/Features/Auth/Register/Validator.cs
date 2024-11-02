using System;
using FluentValidation;

namespace Codebase.API.Features.Auth.Register;

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Email)
            .NotEqual("")
            .WithMessage("Email is required!")
            .EmailAddress()
            .WithMessage("Email must valid email address format");
            
    }
}