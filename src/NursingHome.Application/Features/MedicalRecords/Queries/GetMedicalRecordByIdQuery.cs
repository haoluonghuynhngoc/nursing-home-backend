using MediatR;
using NursingHome.Application.Features.MedicalRecords.Models;

namespace NursingHome.Application.Features.MedicalRecords.Queries;
public record GetMedicalRecordByIdQuery(int Id) : IRequest<MedicalRecordResponse>;