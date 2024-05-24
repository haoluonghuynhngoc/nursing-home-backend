using NursingHome.Domain.Constants;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Infrastructure.Persistence.SeedData;
internal static class RoleSeed
{
    public static IList<Role> Default => new List<Role>()
    {
        new(RoleName.Admin),
        new(RoleName.Director),
        new(RoleName.Manager),
        new(RoleName.Staff),
        new(RoleName.Nurse),
        new(RoleName.Customer)
    };
}
