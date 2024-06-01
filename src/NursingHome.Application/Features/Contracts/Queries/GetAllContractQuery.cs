using MediatR;
using NursingHome.Application.Features.Contracts.Models;
using NursingHome.Domain.Enums;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.Contracts.Queries;
public sealed record GetAllContractQuery : IRequest<PaginatedResponse<ContractResponse>>
{
    /// <summary>
    /// Search field is search for  Name
    /// </summary>
    public string? Search { get; set; }
    /// <summary>
    /// Lọc theo trạng thái hợp đồng bao gồmg : Đang sử dụng, Đã hủy, Hết hạn, bị loại bỏ
    /// </summary>
    public ContractStatus? Status { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
