using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Mappings;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class HrmsContext : DbContext
    {
        public HrmsContext(DbContextOptions<HrmsContext> options) : base(options)
        {

        }

        public HrmsContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CityMap());
            modelBuilder.ApplyConfiguration(new CompanyStaffMap());
            modelBuilder.ApplyConfiguration(new CompanyStaffVerificationMap());
            modelBuilder.ApplyConfiguration(new EmailActivationMap());
            modelBuilder.ApplyConfiguration(new EmployerMap());
            modelBuilder.ApplyConfiguration(new EmployerUpdateMap());
            modelBuilder.ApplyConfiguration(new JobAdvertMap());
            modelBuilder.ApplyConfiguration(new JobPositionMap());
            modelBuilder.ApplyConfiguration(new JobSeekerCvEducationMap());
            modelBuilder.ApplyConfiguration(new JobSeekerCvExperienceMap());
            modelBuilder.ApplyConfiguration(new JobSeekerCvImageMap());
            modelBuilder.ApplyConfiguration(new JobSeekerCvLanguageMap());
            modelBuilder.ApplyConfiguration(new JobSeekerCvMap());
            modelBuilder.ApplyConfiguration(new JobSeekerCvSkillMap());
            modelBuilder.ApplyConfiguration(new JobSeekerCvWebSiteMap());
            modelBuilder.ApplyConfiguration(new JobSeekerMap());
            //modelBuilder.ApplyConfiguration(new JobSeekersFavoriteJobAdvertMap());
            modelBuilder.ApplyConfiguration(new LanguageMap());
            modelBuilder.ApplyConfiguration(new OperationClaimMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new OperationClaimMap());
            modelBuilder.ApplyConfiguration(new WebSiteMap());
            modelBuilder.ApplyConfiguration(new WorkingTimeMap());
            modelBuilder.ApplyConfiguration(new WorkingTypeMap());
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<CompanyStaff> CompanyStaffs { get; set; }
        public DbSet<CompanyStaffVerification> CompanyStaffVerifications { get; set; }
        public DbSet<EmailActivation> EmailActivations { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<EmployerUpdate> EmployerUpdates { get; set; }
        public DbSet<JobAdvert> JobAdverts { get; set; }
        public DbSet<JobPosition> JobPositions { get; set; }
        public DbSet<JobSeeker> JobSeekers { get; set; }
        public DbSet<JobSeekerCv> JobSeekerCvs { get; set; }
        public DbSet<JobSeekerCvEducation> JobSeekerCvEducations { get; set; }
        public DbSet<JobSeekerCvExperience> JobSeekerCvExperiences { get; set; }
        public DbSet<JobSeekerCvImage> JobSeekerCvImages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<JobSeekerCvLanguage> JobSeekerCvLanguages { get; set; }
        public DbSet<JobSeekerCvSkill> JobSeekerCvSkills { get; set; }
        public DbSet<JobSeekerCvWebSite> JobSeekerCvWebSites { get; set; }
        //public DbSet<JobSeekersFavoriteJobAdvert> JobSeekersFavoriteJobAdverts { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<WebSite> WebSites { get; set; }
        public DbSet<WorkingTime> WorkingTimes { get; set; }
        public DbSet<WorkingType> WorkingTypes { get; set; }
    }
}
