namespace NursingHome.Application.Features.Elders.Models;
internal class ElderUserResponse
{
    public Guid Id { get; set; }
    public string? FullName { get; set; }
    public string? AvatarUrl { get; set; }
    public string? Address { get; set; }
    public string? CCCD { get; set; }
    public bool IsActive { get; set; }
    public string? DateOfBirth { get; set; }
}
