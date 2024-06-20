namespace NursingHome.Application.Features.DiseaseCategories.Models;
public record BaseDiseaseCategoryResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
}
