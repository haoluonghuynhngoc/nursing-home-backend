using Bogus;
using NursingHome.Domain.Entities;

namespace NursingHome.Infrastructure.Persistence.SeedData;
internal static class DiseaseCategorySeed
{
    private static readonly List<string> ListDiseaseNames = new List<string>
    {
        "Tiểu đường",
        "Cao huyết áp",
        "Hen suyễn",
        "Bệnh phổi tắc nghẽn mãn tính",
        "Bệnh tim",
        "Ung thư",
        "Đột quỵ",
        "Bệnh Alzheimer",
        "Viêm khớp"
    };

    public static List<DiseaseCategory> Default
    {
        get
        {
            var faker = new Faker();
            var uniqueDiseaseNames = faker.PickRandom(ListDiseaseNames, ListDiseaseNames.Count).ToList();
            return uniqueDiseaseNames.Select(name => new DiseaseCategory { Name = name }).ToList();
        }
    }
}
