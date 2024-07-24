using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.EmployeeTypes.Models;
public record BaseEmployeeTypeResponse : BaseEntityResponse<int>
{
    public EmployeeTypeName Name { get; set; }
}
