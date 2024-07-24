using MediatR;
using NursingHome.Application.Features.EmployeeTypes.Models;

namespace NursingHome.Application.Features.EmployeeTypes.Queries;
public sealed record GetEmployeeTypeByIdQuery(int Id) : IRequest<EmployeeTypeResponse>;
