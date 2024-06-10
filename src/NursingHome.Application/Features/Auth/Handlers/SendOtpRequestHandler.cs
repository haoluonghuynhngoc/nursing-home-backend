using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Features.Auth.Commands;
using NursingHome.Application.Features.Auth.Events;
using NursingHome.Application.Models;
using NursingHome.Domain.Constants;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Application.Features.Auth.Handlers;

internal sealed class SendOtpRequestHandler(
    UserManager<User> userManager,
    ILogger<SendOtpRequestHandler> logger,
    IPublisher publisher,
    IEmailSender emailSender) : IRequestHandler<SendOtpRequest, MessageResponse>
{
    public async Task<MessageResponse> Handle(SendOtpRequest request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByNameAsync(request.PhoneNumber);
        if (user is null)
        {
            user = new User
            {
                UserName = request.PhoneNumber,
                PhoneNumber = request.PhoneNumber,
                IsActive = true,
                PhoneNumberConfirmed = true
            };

            var result = await userManager.CreateAsync(user);

            if (!result.Succeeded)
            {
                throw new ValidationBadRequestException(result.Errors);
            }

            result = await userManager.AddToRoleAsync(user, RoleName.Customer);

            if (!result.Succeeded)
            {
                throw new ValidationBadRequestException(result.Errors);
            }

            //await publisher.Publish(new InitWalletEvent() with { UserId = user.Id }, cancellationToken);
        }

        if (!await userManager.IsInRoleAsync(user, RoleName.Customer))
        {
            throw new ForbiddenAccessException();
        }

        var code = await userManager.GenerateTwoFactorTokenAsync(user, TokenOptions.DefaultPhoneProvider);

        logger.LogInformation($"OTP: {code} ");

        // send otp to phonenumber in background job
        BackgroundJob.Enqueue(() => publisher.Publish(new SendOtpEvent(request.PhoneNumber, code), cancellationToken));
        _ = emailSender.SendEmailAsync("trinmse150418@fpt.edu.vn", "OTP", code, cancellationToken);

        return new MessageResponse(Resource.OtpSendSuccess + $" (OTP: {code})");
    }
}
