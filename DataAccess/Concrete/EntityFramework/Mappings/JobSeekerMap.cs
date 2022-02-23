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
    public class JobSeekerMap : IEntityTypeConfiguration<JobSeeker>
    {
        public void Configure(EntityTypeBuilder<JobSeeker> builder)
        {
            builder.HasKey(j => j.Id);
            builder.Property(j => j.Id).ValueGeneratedOnAdd();
            builder.Property(j => j.FirstName).HasMaxLength(50);
            builder.Property(j => j.FirstName).IsRequired();
            builder.Property(j => j.LastName).HasMaxLength(50);
            builder.Property(j => j.LastName).IsRequired();
            builder.Property(j => j.IdentityNumber).HasMaxLength(11);
            builder.Property(j => j.IdentityNumber).IsRequired();
            builder.Property(j => j.BirthDate).IsRequired();
            builder.HasOne<User>(j => j.User).WithMany(u => u.JobSeekers).HasForeignKey(j => j.UserId);
            builder.HasOne<JobSeekerCv>(j => j.JobSeekerCv).WithMany(j => j.JobSeekers).HasForeignKey(j => j.JobSeekerCvId);
            builder.ToTable("JobSeekers");
        }
    }
}
