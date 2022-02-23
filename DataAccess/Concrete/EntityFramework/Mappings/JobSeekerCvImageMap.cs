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
    public class JobSeekerCvImageMap : IEntityTypeConfiguration<JobSeekerCvImage>
    {
        public void Configure(EntityTypeBuilder<JobSeekerCvImage> builder)
        {
            builder.HasKey(j => j.Id);
            builder.Property(j => j.Id).ValueGeneratedOnAdd();
            builder.Property(j => j.Url).HasMaxLength(250);
            builder.Property(j => j.Url).IsRequired();
            builder.HasOne<JobSeekerCv>(j => j.JobSeekerCv).WithMany(j => j.JobSeekerCvImages).HasForeignKey(j => j.JobSeekerCvId);
            builder.ToTable("JobSeekerCvImages");
        }
    }
}
