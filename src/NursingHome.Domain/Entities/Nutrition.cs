using NursingHome.Domain.Common;

namespace NursingHome.Domain.Entities;
public class Nutrition : BaseEntity<Guid>
{
    // chưa cần sài 
    public string? Name { get; set; }
    public string? Type { get; set; }
    public string? Status { get; set; }
    public string? Ingredients { get; set; }
    public string? Calories { get; set; }
    public string? Protein { get; set; }
    public string? Instructions { get; set; }

    public string? ImageNutrition { get; set; }
    public string? Description { get; set; }
    public string? Note { get; set; }
}
