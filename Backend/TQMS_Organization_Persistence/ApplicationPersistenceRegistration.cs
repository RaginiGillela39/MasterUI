using TQMS_Admin_Application.Contracts.Repository;


namespace TQMS_Organization_Persistence
{
    public static class ApplicationPersistenceRegistration
    {
        public static void ApplicationPersisitenceRegistration(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<OrganizationDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")),ServiceLifetime.Scoped);
            service.AddScoped<IOrganizationRepository, OrganizationRepository>();
            service.AddScoped<IOrganizationTypeRepository, OrganizationTypeRepository>();
            service.AddScoped<IBranchRepository, BranchRepository>();
            service.AddScoped<IDepartmentRepository, DepartmentRepository>();
            service.AddScoped<ILevelsRepository, LevelsRepository>();
            service.AddScoped<ILevelCategoryRepository, LevelCategoryRepository>();
            service.AddScoped<ILevelHierarchyRepository, LevelHierarchyRepository>();
            service.AddScoped<IStatusTypeRepository, StatusTypeRepository>();
            service.AddScoped<IExecutiveWindowRepository, ExecutiveWindowRepository>();
            service.AddScoped<IExecWinCategoryRepository,ExecutiveWindowCategoryRepository>();

        }
    }
}
