using MediatR;
using NursingHome.Application.Features.Records.Models;

namespace NursingHome.Application.Features.Records.Queries;
public sealed record GetRecordByIdQuery(Guid Id) : IRequest<RecordResponse>;

