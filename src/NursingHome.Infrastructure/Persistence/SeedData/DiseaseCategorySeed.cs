using Bogus;
using NursingHome.Domain.Entities;

namespace NursingHome.Infrastructure.Persistence.SeedData;
internal static class DiseaseCategorySeed
{
    private static readonly List<string> ListDiseaseNames = new List<string>
    {
        "Diabetes",
        "Hypertension",
        "Asthma",
        "Chronic Obstructive Pulmonary Disease",
        "Heart Disease",
        "Cancer",
        "Stroke",
        "Alzheimer's Disease",
        "Arthritis"
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
