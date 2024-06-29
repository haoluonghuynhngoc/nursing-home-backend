namespace NursingHome.Application.Features.Images.Models;
public record CreateImageRequest
{
    public string ImageUrl { get; set; } = default!;
}
