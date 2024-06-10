using NursingHome.Domain.Common;

namespace NursingHome.Application.Features.Auth.Events;
internal sealed record SendOtpEvent(string PhoneNumber, string Otp) : BaseEvent;
