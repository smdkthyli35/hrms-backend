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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=Hrms; Trusted_Connection=true");
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
        public DbSet<JobSeekerCvLanguage> jobSeekerCvLanguages { get; set; }
        public DbSet<JobSeekerCvSkill> JobSeekerCvSkills { get; set; }
        public DbSet<JobSeekerCvWebSite> JobSeekerCvWebSites { get; set; }
        public DbSet<JobSeekersFavoriteJobAdvert> JobSeekersFavoriteJobAdverts { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<WebSite> WebSites { get; set; }
        public DbSet<WorkingTime> WorkingTimes { get; set; }
        public DbSet<WorkingType> WorkingTypes { get; set; }
    }
}
