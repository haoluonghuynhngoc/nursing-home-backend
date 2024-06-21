using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.MedicalRecords.Commands;
using NursingHome.Application.Features.MedicalRecords.Models;
using NursingHome.Application.Features.MedicalRecords.Queries;
using NursingHome.Application.Models;
using NursingHome.Shared.Pages;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class MedicalRecordsController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<MedicalRecordResponse>>> GetAllMedicalRecordsWithPaginAsync(
     [FromQuery] GetMedicalRecordsQuery query,
     CancellationToken cancellationToken)
    {
        return await sender.Send(query, cancellationToken);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MedicalRecordResponse>> GetMedicalRecordByIdAsync(
        int id,
        CancellationToken cancellationToken)
    {
        return await sender.Send(new GetMedicalRecordByIdQuery(id), cancellationToken);
    }

    /// <summary>
    /// Vì đây là bảng 1-1 nên khi tọa elder thì có luôn rồi nên không cần tạo riêng
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<MessageResponse>> CreateMedicalRecordAsync(
        CreateMedicalRecordCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdateMedicalRecordAsync(
        int id,
        UpdateMedicalRecordCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<MessageResponse>> DeleteMedicalRecordAsync(int id, CancellationToken cancellationToken)
    {
        return await sender.Send(new DeleteMedicalRecordCommand(id), cancellationToken);
    }
}
