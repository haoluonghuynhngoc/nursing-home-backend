using NursingHome.Application.Models;

namespace NursingHome.Application.Features.Images.Models;
public record ImageResponse : BaseEntityResponse<int>
{
    public string ImageUrl { get; set; } = default!;
}
