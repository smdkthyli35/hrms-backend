using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class JobSeekerCvExperienceMap : IEntityTypeConfiguration<JobSeekerCvExperience>
    {
        public void Configure(EntityTypeBuilder<JobSeekerCvExperience> builder)
        {
            builder.HasKey(j => j.Id);
            builder.Property(j => j.Id).ValueGeneratedOnAdd();
            builder.Property(j => j.WorkplaceName).HasMaxLength(100);
            builder.Property(j => j.WorkplaceName).IsRequired();
            builder.Property(j => j.StartDate).IsRequired();
            builder.HasOne<JobSeekerCv>(j => j.JobSeekerCv).WithMany(j => j.JobSeekerCvExperiences).HasForeignKey(j => j.JobSeekerCvId);
            builder.HasOne<JobPosition>(j => j.JobPosition).WithMany(j => j.JobSeekerCvExperiences).HasForeignKey(j => j.JobPositionId);
            builder.ToTable("JobSeekerCvExperiences");
        }
    }
}
