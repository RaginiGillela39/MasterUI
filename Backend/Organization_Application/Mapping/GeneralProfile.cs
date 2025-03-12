


using TQMS_Admin_Application.Features.ExecutiveWindow.Command.CreateExecutiveWindow;
using TQMS_Admin_Application.Features.ExecutiveWindowCategoryCategory.Command.CreateExecutiveWindowCategoryCategory;
using TQMS_Admin_Application.Features.LevelCategory.Command.CreateLevelCategory;
using TQMS_Admin_Application.Features.LevelHierarchy.Command.CreateLevelHierarchy;
using TQMS_Admin_Application.Features.Levels.Commands.CreateLevels;
using TQMS_Admin_Application.Features.StatusType.Command.CreateStatusType;
using TQMS_Department_Application.Features.Department.Command.CreateDepartment;

namespace TQMS_Organization_Application.Mapping
{
    public class GeneralProfile:Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateOrganizationCommand, Organization>();
            CreateMap<CreateOrganizationTypeCommand, OrganizationType>();
            CreateMap<CreateBranchCommand, Branch>();
            CreateMap<CreateDepartmentCommand, Department>();
            CreateMap<CreateLevelsCommand, Levels>();
            CreateMap<CreateLevelCategoryCommand, LevelCategory>();
            CreateMap<CreateLevelHierarchyCommand, LevelHierarchy>();
            CreateMap<CreateExecutiveWindowCommand, ExecutiveWindow>();
            CreateMap<CreateExecutiveWindowCategoryCommand, ExecutiveWindowCategory>();
            CreateMap<CreateStatusTypeCommand, StatusType>();
        }
    }
}
