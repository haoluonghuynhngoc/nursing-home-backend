using FluentValidation;

namespace NursingHome.Application.Features.Users.Commands;
public sealed class ResetPasswordRequestValidator : AbstractValidator<ResetPasswordRequest>
{
    public ResetPasswordRequestValidator()
    {
        RuleFor(x => x.NewPassword)
            .NotEmpty();
    }
}
