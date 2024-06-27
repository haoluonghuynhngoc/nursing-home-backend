using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CareScheduleController(ISender sender) : ControllerBase
{
}
