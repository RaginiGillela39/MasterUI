

namespace TQMS_Organization_Application
{
    public static class ApplicationRegistration
    {
        public static void AddApplicationRegistration(this IServiceCollection services)
        {
            var assembly= Assembly.GetAssembly(typeof(CreateOrganizationCommandHandler)) ?? throw new InvalidOperationException("Unable to load the assembly for CreateCallTypeCommandHandler.");
            services.AddMediatR(configuration=>configuration.RegisterServicesFromAssembly(assembly));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //Register validation 
            services.AddScoped<IOrganizationValidator, OrganizationValidation>();
            services.AddScoped<IOrganizationTypevalidator,OrganizationTypeValidation>();
            services.AddScoped<IBranchValidator,BranchValidation>();
            services.AddScoped<IDepartmentValidator,DepartmentValidation>();
            services.AddScoped<ILevelsValidator, LevelsValidation>();
            services.AddScoped<ILevelHierarchyValidator, LevelHierarchyValidation>();
            services.AddScoped<ILevelCategoryValidator, LevelCategoryValidation>();
            services.AddScoped<IStatusTypeValidator, StatusTypeValidation>();
            services.AddScoped<IExecutiveWindowValidator, ExecutiveWindowValidation>();
            services.AddScoped<IExecWinCategoryValidator, ExecWinCategoryValidation>();
        }
    }
}
