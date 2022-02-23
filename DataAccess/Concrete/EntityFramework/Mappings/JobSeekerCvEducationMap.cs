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
    public class JobSeekerCvEducationMap : IEntityTypeConfiguration<JobSeekerCvEducation>
    {
        public void Configure(EntityTypeBuilder<JobSeekerCvEducation> builder)
        {
            builder.HasKey(j => j.Id);
            builder.Property(j => j.Id).ValueGeneratedOnAdd();
            builder.Property(j => j.SchoolName).HasMaxLength(50);
            builder.Property(j => j.SchoolName).IsRequired();
            builder.Property(j => j.DepartmentName).HasMaxLength(50);
            builder.Property(j => j.DepartmentName).IsRequired();
            builder.Property(j => j.StartDate).IsRequired();
            builder.HasOne<JobSeekerCv>(j => j.JobSeekerCv).WithMany(j => j.JobSeekerCvEducations).HasForeignKey(j => j.JobSeekerCvId);
            builder.ToTable("JobSeekerCvEducations");
        }
    }
}
