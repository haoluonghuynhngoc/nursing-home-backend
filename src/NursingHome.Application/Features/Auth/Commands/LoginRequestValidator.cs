using FluentValidation;
using NursingHome.Application.Common.Resources;

namespace NursingHome.Application.Features.Auth.Commands;
public sealed class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Username).NotEmpty().WithMessage(Resource.UsernameRequired);
        RuleFor(x => x.Password).NotEmpty().WithMessage(Resource.PasswordRequired);
    }
}
