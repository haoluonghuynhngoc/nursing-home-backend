using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.Statistical.Models;
using NursingHome.Application.Features.Statistical.Queries;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class StatisticalController(ISender sender) : ControllerBase
{
    [HttpGet("elder")]
    public async Task<ActionResult<TotalElderResponse>> GetStatiscalElder(
         CancellationToken cancellationToken)
    {
        return await sender.Send(new GetAllTotalElderQuery(), cancellationToken);
    }
    [HttpGet("money")]
    public async Task<ActionResult<TotalMoneyResponse>> GetStatiscalMoney(
        CancellationToken cancellationToken)
    {
        return await sender.Send(new GetAllTotalMoneyQuery(), cancellationToken);
    }
    [HttpGet("user")]
    public async Task<ActionResult<TotalUserResponse>> GetStatiscalUser(
        CancellationToken cancellationToken)
    {
        return await sender.Send(new GetAllTotalUserQuery(), cancellationToken);
    }
    [HttpGet("{year}")]
    public async Task<ActionResult<Dictionary<int, StatisticalResponse>>> GetAllStatiscalInYearAsync(
        int year,
        CancellationToken cancellationToken)
    {
        return await sender.Send(new GetAllTotalInYearQuery(year), cancellationToken);
    }
}
