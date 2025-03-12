

namespace TQMS_Organization_Infrastructure.Data
{
    public class OrganizationDBContext:DbContext
    {
        public OrganizationDBContext(DbContextOptions<OrganizationDBContext> options):base(options) { }

        public DbSet<Organization> Organizations { get; set; }

        public DbSet<OrganizationType> OrganizationsType { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Department> Department { get; set; }

        public DbSet<Levels> Levels { get; set; }
        public DbSet<LevelHierarchy> LevelHierarchy { get; set; }
        public DbSet<LevelCategory> LevelCategories { get; set; }

        public DbSet<StatusType> StatusTypes { get; set; }

        public DbSet<ExecutiveWindow> ExecutiveWindow { get; set; }
        public DbSet<ExecutiveWindowCategory> ExecutiveWindowCategories {  get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrganizationDBContext).Assembly);
            modelBuilder.Entity<Organization>()
                 .HasOne<OrganizationType>()
                 .WithMany()
                 .HasForeignKey(o => o.Type)
                 .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Levels>()
                 .HasOne<Organization>()
                 .WithMany()
                 .HasForeignKey(o => o.Organization_Id)
                 .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Levels>()
                 .HasOne<Department>()
                 .WithMany()
                 .HasForeignKey(o => o.Department_Id)
                 .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Levels>()
                 .HasOne<Branch>()
                 .WithMany()
                 .HasForeignKey(o => o.Branch_Id)
                 .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<LevelCategory>()
                 .HasOne<Levels>()
                 .WithMany()
                 .HasForeignKey(o => o.Level_Id)
                 .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<LevelHierarchy>()
                 .HasOne<Levels>()
                 .WithMany()
                 .HasForeignKey(o => o.Level_Id)
                 .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ExecutiveWindow>()
                 .HasOne<Levels>()
                 .WithMany()
                 .HasForeignKey(o => o.Level_Id)
                 .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ExecutiveWindow>()
                 .HasOne<StatusType>()
                 .WithMany()
                 .HasForeignKey(o => o.StatusType_Id)
                 .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ExecutiveWindowCategory>()
                 .HasOne<LevelCategory>()
                 .WithMany()
                 .HasForeignKey(o => o.LevelCategory_Id)
                 .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ExecutiveWindowCategory>()
                 .HasOne<LevelCategory>()
                 .WithMany()
                 .HasForeignKey(o => o.ExecutiveWindow_Id)
                 .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Branch>()
                 .HasOne<Organization>()
                 .WithMany()
                 .HasForeignKey(o => o.Org_Id)
                 .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Department>()
                .HasOne<Organization>()
                .WithMany()
                .HasForeignKey(o => o.Org_Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
