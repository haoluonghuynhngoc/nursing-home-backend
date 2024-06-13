using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Users.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Constants;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Application.Features.Users.Handlers;
internal class RegisterCutomerCommandHandler(
    UserManager<User> userManager,
    IUnitOfWork unitOfWork) : IRequestHandler<RegisterCutomerCommand, MessageResponse>
{
    public async Task<MessageResponse> Handle(RegisterCutomerCommand request, CancellationToken cancellationToken)
    {

        var user = await userManager.FindByNameAsync(request.PhoneNumber);
        if (user != null)
        {
            throw new BadRequestException(Resource.UserAlreadyExists);
        }
        var customer = new User();
        request.Adapt(customer);
        customer.IsActive = true;

        if (request.Password == null)
        {
            await userManager.CreateAsync(customer, "1"); // sau này sẽ randome password bằng otp sms 
        }
        else
        {
            await userManager.CreateAsync(customer, request.Password);
        }

        await userManager.AddToRolesAsync(customer, new[] { RoleName.Customer });
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreateUserSuccessMessage);
    }
}
