using FluentValidation;
using NursingHome.Application.Common.Resources;
using NursingHome.Shared.Extensions;

namespace NursingHome.Application.Features.Auth.Commands;
public sealed class SendOtpRequestValidator : AbstractValidator<SendOtpRequest>
{
    public SendOtpRequestValidator()
    {
        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithMessage(Resource.PhoneNumberRequired)
            .Matches(RegexExtensions.PhoneRegex)
            .WithMessage(Resource.PhoneNumberInvalid);
    }
}
