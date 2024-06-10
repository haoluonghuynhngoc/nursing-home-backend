using FluentValidation;
using NursingHome.Application.Common.Resources;
using NursingHome.Shared.Extensions;

namespace NursingHome.Application.Features.Auth.Commands;
public sealed class VerifyOtpRequestValidator : AbstractValidator<VerifyOtpRequest>
{
    public VerifyOtpRequestValidator()
    {
        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithMessage(Resource.PhoneNumberRequired)
            .Matches(RegexExtensions.PhoneRegex)
            .WithMessage(Resource.PhoneNumberInvalid);

        RuleFor(x => x.Otp)
            .NotEmpty()
            .WithMessage(Resource.OtpRequired)
            .Matches(RegexExtensions.OtpRegex)
            .WithMessage(Resource.OtpInvalid);
    }
}
