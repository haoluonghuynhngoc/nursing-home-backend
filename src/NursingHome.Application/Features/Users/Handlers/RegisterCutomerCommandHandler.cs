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
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();
    public async Task<MessageResponse> Handle(RegisterCutomerCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.ExistsByAsync(_ => _.PhoneNumber == request.PhoneNumber))
        {
            throw new FieldResponseException(600, $"Phone number Is {request.PhoneNumber} already exists.");
        }
        if (await _userRepository.ExistsByAsync(_ => _.Email == request.Email && request.Email != null))
        {
            throw new FieldResponseException(601, $"Email Is {request.Email} already exists.");
        }
        if (await _userRepository.ExistsByAsync(_ => _.CCCD == request.CCCD && request.CCCD != null))
        {
            throw new FieldResponseException(602, $"CCCD Is {request.CCCD} already exists.");
        }

        var user = await userManager.FindByNameAsync(request.PhoneNumber);
        if (user != null)
        {
            throw new FieldResponseException(603, Resource.UserAlreadyExists);
        }

        var customer = request.Adapt<User>();
        customer.UserName = request.PhoneNumber;
        customer.IsActive = true;
        customer.PhoneNumberConfirmed = true;

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
