using FluentValidation;
using NursingHome.Application.Common.Resources;

namespace NursingHome.Application.Features.Auth.Commands;
public class RefreshTokenRequestValidator : AbstractValidator<RefreshTokenRequest>
{
    public RefreshTokenRequestValidator()
    {
        RuleFor(x => x.RefreshToken).NotEmpty().WithMessage(Resource.RefreshTokenRequired);
    }
}

