using Microsoft.EntityFrameworkCore;
using System;

namespace ServicesWebApp.Entities.PortalWebApp
{
    public partial class PortalRepositoryContext : DbContext
    {
        public PortalRepositoryContext()
        {

        }

        public PortalRepositoryContext(DbContextOptions<PortalRepositoryContext> options) : base(options)
        {

        }

        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<BranchCompany> BranchCompanies { get; set; }
        public virtual DbSet<BusinessUnit> BusinessUnits { get; set; }
        public virtual DbSet<PersonApplication> PersonApplications { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<vtPerson> vtPersons { get; set; }
        public virtual DbSet<TokenApplication> TokenApplications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var filename = $"appsettings.{envName}.json";
            filename = filename.Replace("..", ".");
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                 .AddJsonFile(filename, optional: false)
                 .Build();

            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.EnableDetailedErrors(true);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("PortalConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>(entity =>
            {
                entity.HasKey(e => e.IdApplication);

                entity.ToTable("Application");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.URL)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.OfflineMessage)
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.IdPosition);

                entity.ToTable("Position");

                entity.Property(e => e.IdCompany)
                   .HasMaxLength(50);             

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Guid)
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BranchCompany>(entity =>
            {
                entity.HasKey(e => e.IdBranchCompany);

                entity.ToTable("BranchCompany");

                entity.Property(e => e.IdCompany)
                  .HasMaxLength(10);

                entity.Property(e => e.RFC)
                    .HasMaxLength(20);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Nickname)
                    .HasMaxLength(50);

                entity.Property(e => e.isDefault)
                    .HasMaxLength(10);

                entity.Property(e => e.Status)
                  .IsRequired()
                  .HasMaxLength(10);

                entity.Property(e => e.Guid)
                    .HasMaxLength(50);

            });

            modelBuilder.Entity<BusinessUnit>(entity =>
            {
                entity.HasKey(e => e.IdBusinessUnit);

                entity.ToTable("BusinessUnit");
                entity.Property(e => e.IdCompany)
                   .IsRequired()
                   .HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Nickname)
                    .HasMaxLength(50);

                entity.Property(e => e.Address)
                   .HasMaxLength(500);

                entity.Property(e => e.ExteriorNumber)
                   .HasMaxLength(10);

                entity.Property(e => e.InteriorNumber)
                   .HasMaxLength(10);

                entity.Property(e => e.IdCountry)
                   .HasMaxLength(10);

                entity.Property(e => e.IdState)
                   .HasMaxLength(10);

                entity.Property(e => e.IdMunicipality)
                   .HasMaxLength(10);

                entity.Property(e => e.IdLocality)
                   .HasMaxLength(10);

                entity.Property(e => e.IdColony)
                   .HasMaxLength(10);

                entity.Property(e => e.PostalCode)
                   .HasMaxLength(20);

                entity.Property(e => e.PhoneNumber)
                   .HasMaxLength(20);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Guid)
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TokenApplication>(entity =>
            {
                entity.HasKey(e => e.IdToken);

                entity.ToTable("TokenApplication");

                entity.Property(e => e.IdApplication)
                    .HasMaxLength(10);

                entity.Property(e => e.Description)
                    .HasMaxLength(100);

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(550);

                entity.Property(e => e.DescriptionApplicationExternal)
                    .HasMaxLength(250);

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(10);

                entity.Property(e => e.Status)
                    .HasMaxLength(10);

            });

            modelBuilder.Entity<PersonApplication>(entity =>
            {
                entity.HasKey(e => new { e.IdPerson, e.IdApplication });

                entity.ToTable("PersonApplication");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.IdDepartment);

                entity.ToTable("Department");

                entity.Property(e => e.IdCompany)
                  .IsRequired()
                  .HasMaxLength(10);

                entity.Property(e => e.IdCostCenter)
                   .HasMaxLength(30);

                entity.Property(e => e.Classification)
                    .HasMaxLength(50);

                entity.Property(e => e.AccountingGroup)
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Status)
                 .IsRequired()
                 .HasMaxLength(10);

                entity.Property(e => e.Guid)
                    .HasMaxLength(50);

            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.IdPerson);

                entity.ToTable("Person");

                entity.Property(e => e.IdUserAzure)
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20);

                entity.Property(e => e.Email)
                    .HasMaxLength(150);

                entity.Property(e => e.Username)
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Image)
                    .HasMaxLength(50);

                entity.Property(e => e.EmployeeNumber)
                      .HasMaxLength(10);

                entity.Property(e => e.PersonalMail)
                    .HasMaxLength(50);

                entity.Property(e => e.Curp)
                    .HasMaxLength(50);

                entity.Property(e => e.Nss)
                    .HasMaxLength(50);

                entity.Property(e => e.BloodType)
                    .HasMaxLength(10);

                entity.Property(e => e.StartDateJob)
                   .HasMaxLength(50);

                entity.Property(e => e.PersonalPhone)
                    .HasMaxLength(20);

                entity.Property(e => e.EmergencyNumber)
                  .HasMaxLength(20);

                entity.Property(e => e.Allergies)
               .HasMaxLength(500);

                entity.Property(e => e.CustomFullName)
               .HasMaxLength(200);

                entity.Property(e => e.IdCivilStatus)
                 .HasMaxLength(10);

                entity.Property(e => e.Nationality)
                    .HasMaxLength(50);

                entity.Property(e => e.Birthdate)
                  .HasMaxLength(50);

                entity.Property(e => e.IsRehirable)
              .HasMaxLength(10);

                entity.Property(e => e.IdImmediateBoss)
                .HasMaxLength(10);

                entity.Property(e => e.IdFuntionalBoss)
                .HasMaxLength(10);

                entity.Property(e => e.ExperienceSummary)
                  .HasMaxLength(512);

                entity.Property(e => e.CorporateNumber)
                  .HasMaxLength(50);

            });

            modelBuilder.Entity<vtPerson>(entity =>
            {
                entity.HasKey(e => e.IdPerson);

                entity.ToTable("vtPerson");

                entity.Property(e => e.IdUserAzure)
                    .HasMaxLength(50);

                entity.Property(e => e.TypeAccountName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CompanyRFC)
                    .HasMaxLength(20);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(150);

                entity.Property(e => e.CompanyNickname)
                    .HasMaxLength(50);

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(150);

                entity.Property(e => e.PositionName)
                    .HasMaxLength(150);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20);

                entity.Property(e => e.Email)
                    .HasMaxLength(150);

                entity.Property(e => e.Username)
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Image)
                    .HasMaxLength(50);

                entity.Property(e => e.EmployeeNumber)
                      .HasMaxLength(10);

                entity.Property(e => e.PersonalMail)
                    .HasMaxLength(50);

                entity.Property(e => e.Curp)
                    .HasMaxLength(50);

                entity.Property(e => e.Nss)
                    .HasMaxLength(50);

                entity.Property(e => e.BloodType)
                    .HasMaxLength(10);

                entity.Property(e => e.StartDateJob)
                   .HasMaxLength(50);

                entity.Property(e => e.PersonalPhone)
                    .HasMaxLength(20);

                entity.Property(e => e.EmergencyNumber)
                  .HasMaxLength(20);

                entity.Property(e => e.Allergies)
                  .HasMaxLength(500);

                entity.Property(e => e.CustomFullName)
               .HasMaxLength(200);

                entity.Property(e => e.IdCivilStatus)
                  .HasMaxLength(10);

                entity.Property(e => e.CivilStatus)
                  .HasMaxLength(50);

                entity.Property(e => e.Nationality)
                    .HasMaxLength(50);

                entity.Property(e => e.Birthdate)
                  .HasMaxLength(50);

                entity.Property(e => e.IsRehirable)
             .HasMaxLength(10);

                entity.Property(e => e.IdImmediateBoss)
               .HasMaxLength(10);

                entity.Property(e => e.IdFuntionalBoss)
                .HasMaxLength(10);

                entity.Property(e => e.ExperienceSummary)
                 .HasMaxLength(512);



            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
