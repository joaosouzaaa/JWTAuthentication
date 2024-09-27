﻿using FluentValidation;
using JWTAuthentication.API.Entities;

namespace JWTAuthentication.API.Validators;

public sealed class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        const string invalidLengthMessage = "Invalid length";

        RuleFor(u => u.UserName)
            .EmailAddress()
            .WithMessage("Invalid User Name format.")
            .Length(5, 100)
            .WithMessage(invalidLengthMessage);

        RuleFor(u => u.PasswordHash)
            .Length(5, 100)
            .WithMessage(invalidLengthMessage);
    }
}
