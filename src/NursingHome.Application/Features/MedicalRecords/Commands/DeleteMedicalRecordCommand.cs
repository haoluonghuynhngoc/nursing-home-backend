using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.MedicalRecords.Commands;
public record DeleteMedicalRecordCommand(int Id) : IRequest<MessageResponse>;