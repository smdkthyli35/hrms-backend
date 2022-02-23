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
    public class JobSeekerCvSkillMap : IEntityTypeConfiguration<JobSeekerCvSkill>
    {
        public void Configure(EntityTypeBuilder<JobSeekerCvSkill> builder)
        {
            builder.HasKey(j => j.Id);
            builder.Property(j => j.Id).ValueGeneratedOnAdd();
            builder.Property(j => j.Name).HasMaxLength(50);
            builder.Property(j => j.Name).IsRequired();
            builder.HasOne<JobSeekerCv>(j => j.JobSeekerCv).WithMany(j => j.JobSeekerCvSkills).HasForeignKey(j => j.JobSeekerCvId);
        }
    }
}
