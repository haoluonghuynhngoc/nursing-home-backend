using NursingHome.Domain.Constants;

namespace NursingHome.Application.Common.Constants;

public abstract class Policies
{

    public const string Admin = $"{RoleName.Admin}";
    public const string Director = $"{RoleName.Director}";
    public const string Manager = $"{RoleName.Manager}";
    public const string Staff = $"{RoleName.Staff}";
    public const string Nurse = $"{RoleName.Nurse}";
    public const string Customer = $"{RoleName.Customer}";

    //public const string StationManager_Or_Staff = $"{RoleName.Nurses},{RoleName.Staff}";
    //public const string Admin_Or_StationManager = $"{RoleName.Manager},{RoleName.Admin}";
    //public const string StationManager_Or_Staff_Or_Admin = $"{RoleName.StationManager},{RoleName.Staff},{RoleName.Admin}";
}