﻿global using TQMS_Organization_Persistence;
global using TQMS_Organization_Application;
global using Microsoft.AspNetCore.Mvc;
global using MediatR;
global using TQMS_Organization_Application.Constant;
global using TQMS_Organization_Application.Features.Organization.Commands.CreateOrganization;
global using TQMS_Organization_Application.Features.Organization.Commands.DeleteOraganization;
global using TQMS_Organization_Application.Features.Organization.Commands.ReactiveOrganization;
global using TQMS_Organization_Application.Features.Organization.Commands.UpdateOrganization;
global using TQMS_Organization_Application.Features.Organization.Queries.GetActiveOrganization;
global using TQMS_Organization_Application.Features.Organization.Queries.GetAllOrganization;
global using TQMS_Organization_Application.Features.Organization.Queries.GetOrganizationById;
global using TQMS_Organization_Application.Features.OrganizationType.Commands.CreateOrganizationTYpe;
global using TQMS_Organization_Application.Features.OrganizationType.Commands.DeleteOrganizationType;
global using TQMS_Organization_Application.Features.OrganizationType.Commands.ReactivateOrganizationType;
global using TQMS_Organization_Application.Features.OrganizationType.Commands.UpdateOrganizationType;
global using TQMS_Organization_Application.Features.OrganizationType.Queries.GetAllActiveQuery;
global using TQMS_Organization_Application.Features.OrganizationType.Queries.GetAllQuery;
global using TQMS_Organization_Application.Features.OrganizationType.Queries.GetByIdQuery;
global using TQMS_Branch_Application.Features.Branch.Command.CreateBranch;
global using TQMS_Branch_Application.Features.Branch.Command.DeleteBranch;
global using TQMS_Branch_Application.Features.Branch.Command.ReactiveBranch;
global using TQMS_Branch_Application.Features.Branch.Command.UpdateBranch;
global using TQMS_Branch_Application.Features.Branch.Queries.GetActiveBranch;
global using TQMS_Branch_Application.Features.Branch.Queries.GetAllBranch;
global using TQMS_Branch_Application.Features.Branch.Queries.GetBranchById;
global using TQMS_Department_Application.Features.Department.Command.CreateDepartment;
global using TQMS_Department_Application.Features.Department.Command.DeleteDepartment;
global using TQMS_Department_Application.Features.Department.Command.ReactiveDepartment;
global using TQMS_Department_Application.Features.Department.Command.UpdateDepartment;
global using TQMS_Department_Application.Features.Department.Queries.GetActiveDepartment;
global using TQMS_Department_Application.Features.Department.Queries.GetDepartmentById;
global using TQMS_Organization_Application.Features.Department.Queries.GetAllDepartment;

global using TQMS_Admin_Application.Features.ExecutiveWindowCategory.Command.DeleteExecutiveWindowCategory;
global using TQMS_Admin_Application.Features.ExecutiveWindowCategory.Queries.GetActiveExecutiveWindowCategory;
global using TQMS_Admin_Application.Features.ExecutiveWindowCategory.Queries.GetAllExecutiveWindowCategory;
global using TQMS_Admin_Application.Features.ExecutiveWindowCategory.Queries.GetExecutiveWindowCategoryById;
global using TQMS_Admin_Application.Features.ExecutiveWindowCategoryCategory.Command.CreateExecutiveWindowCategoryCategory;
global using TQMS_Admin_Application.Features.ExecutiveWindowCategoryCategory.Command.ReactiveExecutiveWindowCategoryCategory;
global using TQMS_Admin_Application.Features.ExecutiveWindowCategoryCategory.Command.UpdateExecutiveWindowCategoryCategory;

global using TQMS_Admin_Application.Features.ExecutiveWindow.Command.CreateExecutiveWindow;
global using TQMS_Admin_Application.Features.ExecutiveWindow.Command.DeleteExecutiveWindow;
global using TQMS_Admin_Application.Features.ExecutiveWindow.Command.ReactiveExecutiveWindow;
global using TQMS_Admin_Application.Features.ExecutiveWindow.Command.UpdateExecutiveWindow;
global using TQMS_Admin_Application.Features.ExecutiveWindow.Queries.GetActiveExecutiveWindow;
global using TQMS_Admin_Application.Features.ExecutiveWindow.Queries.GetAllExecutiveWindow;
global using TQMS_Admin_Application.Features.ExecutiveWindow.Queries.GetExecutiveWindowById;

global using TQMS_Admin_Application.Features.Levels.Commands.CreateLevels;
global using TQMS_Admin_Application.Features.Levels.Commands.DeleteLevels;
global using TQMS_Admin_Application.Features.Levels.Commands.ReactiveLevels;
global using TQMS_Admin_Application.Features.Levels.Commands.Updatelevels;
global using TQMS_Admin_Application.Features.Levels.Queries.GetActiveLevels;
global using TQMS_Admin_Application.Features.Levels.Queries.GetAllLevels;
global using TQMS_Admin_Application.Features.Levels.Queries.GetLevelsById;

global using TQMS_Admin_Application.Features.LevelHierarchy.Command.CreateLevelHierarchy;
global using TQMS_Admin_Application.Features.LevelHierarchy.Command.DeleteLevelHierarchy;
global using TQMS_Admin_Application.Features.LevelHierarchy.Command.ReactiveLevelHierarchy;
global using TQMS_Admin_Application.Features.LevelHierarchy.Command.UpdateLevelHierarchy;
global using TQMS_Admin_Application.Features.LevelHierarchy.Queries.GetActiveLevelHierarchy;
global using TQMS_Admin_Application.Features.LevelHierarchy.Queries.GetAllLevelHierarchy;
global using TQMS_Admin_Application.Features.LevelHierarchy.Queries.GetLevelHierarchyById;

global using TQMS_Admin_Application.Features.LevelCategory.Command.CreateLevelCategory;
global using TQMS_Admin_Application.Features.LevelCategory.Command.DeleteLevelCategory;
global using TQMS_Admin_Application.Features.LevelCategory.Command.ReactiveLevelCategory;
global using TQMS_Admin_Application.Features.LevelCategory.Command.UpdateLevelCategory;
global using TQMS_Admin_Application.Features.LevelCategory.Queries.GetActiveLevelCategory;
global using TQMS_Admin_Application.Features.LevelCategory.Queries.GetAllLevelCategory;
global using TQMS_Admin_Application.Features.LevelCategory.Queries.GetLevelCategoryById;

global using TQMS_Admin_Application.Features.StatusType.Command.CreateStatusType;
global using TQMS_Admin_Application.Features.StatusType.Command.DeleteStatusType;
global using TQMS_Admin_Application.Features.StatusType.Command.ReactiveStatusType;
global using TQMS_Admin_Application.Features.StatusType.Command.UpdateStatusType;
global using TQMS_Admin_Application.Features.StatusType.Queries.GetActiveStatusType;
global using TQMS_Admin_Application.Features.StatusType.Queries.GetAllStatusType;
global using TQMS_Admin_Application.Features.StatusType.Queries.GetStatusTypeById;

global using Serilog;