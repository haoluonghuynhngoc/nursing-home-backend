﻿namespace NursingHome.Application.Contracts.Services;
public interface ISmsSender
{
    Task SendAsync(string phoneNumber, string message, CancellationToken cancellationToken = default);
}
