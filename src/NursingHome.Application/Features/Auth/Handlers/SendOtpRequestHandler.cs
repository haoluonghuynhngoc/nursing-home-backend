using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Features.Auth.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Constants;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Application.Features.Auth.Handlers;

internal sealed class SendOtpRequestHandler(
    UserManager<User> userManager,
    ILogger<SendOtpRequestHandler> logger,
    ISmsSender smsSender,
    IPublisher publisher,
    IEmailSender emailSender) : IRequestHandler<SendOtpRequest, MessageResponse>
{
    public async Task<MessageResponse> Handle(SendOtpRequest request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByNameAsync(request.PhoneNumber);
        if (user is null)
        {
            throw new NotFoundException(nameof(User), request.PhoneNumber);
        }

        if (!await userManager.IsInRoleAsync(user, RoleName.Customer))
        {
            throw new ForbiddenAccessException();
        }

        var code = await userManager.GenerateTwoFactorTokenAsync(user, TokenOptions.DefaultPhoneProvider);

        logger.LogInformation($"OTP: {code}");

        string message = $"Xác minh OTP từ Nursing Home\n\n{user.UserName} thân mến,\n\nMã OTP của bạn là: {code}\n\nVui lòng nhập mã này để hoàn tất quá trình xác minh. Mã này sẽ hết hạn sau 5 phút.\n\nNếu bạn không yêu cầu mã này, vui lòng bỏ qua tin nhắn này.\n\nCảm ơn bạn,\nNursing Home";
        if (!string.IsNullOrEmpty(user.PhoneNumber))
        {
            // Gửi mã OTP qua SMS
            await smsSender.SendAsync(user.PhoneNumber, message, cancellationToken);
        }
        // Trả về kết quả
        return new MessageResponse(Resource.OtpSendSuccess + $" (OTP: {code})");
    }

}
