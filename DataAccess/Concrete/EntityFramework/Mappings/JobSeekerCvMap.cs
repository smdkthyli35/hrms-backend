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
    public class JobSeekerCvMap : IEntityTypeConfiguration<JobSeekerCv>
    {
        public void Configure(EntityTypeBuilder<JobSeekerCv> builder)
        {
            builder.HasKey(j => j.Id);
            builder.Property(j => j.Id).ValueGeneratedOnAdd();
            builder.Property(j => j.CoverLetter).HasMaxLength(250);
            builder.Property(j => j.CoverLetter).IsRequired();
            builder.HasOne<JobSeeker>(j => j.JobSeeker).WithMany(j => j.JobSeekerCvs).HasForeignKey(j => j.JobSeekerId);
            builder.ToTable("JobSeekerCvs");
        }
    }
}
