using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validator;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        //Email
        RuleFor(temp => temp.email).NotEmpty().EmailAddress();

        //Password
        RuleFor(temp => temp.password).NotEmpty();
    }
}

