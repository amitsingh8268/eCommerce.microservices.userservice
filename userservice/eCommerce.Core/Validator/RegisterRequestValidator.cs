using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validator;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(temp => temp.firstName).NotEmpty();
        RuleFor(temp => temp.lastName).NotEmpty();
        RuleFor(temp => temp.email).NotEmpty().EmailAddress();
        RuleFor(temp => temp.password).NotEmpty();
        RuleFor(x => x.gender)
        .IsInEnum();
    }
}

