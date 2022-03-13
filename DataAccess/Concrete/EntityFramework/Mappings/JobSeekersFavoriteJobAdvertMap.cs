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
    public class JobSeekersFavoriteJobAdvertMap : IEntityTypeConfiguration<JobSeekersFavoriteJobAdvert>
    {
        public void Configure(EntityTypeBuilder<JobSeekersFavoriteJobAdvert> builder)
        {
            builder.HasKey(j => j.Id);
            builder.Property(j => j.Id).ValueGeneratedOnAdd();
            builder.Property(j => j.CreatedByName).IsRequired().HasMaxLength(50);
            builder.Property(j => j.ModifiedByName).IsRequired().HasMaxLength(50);
            builder.Property(j => j.ModifiedDate).IsRequired();
            builder.Property(j => j.CreatedDate).IsRequired();
            builder.Property(j => j.IsActive).IsRequired();
            builder.Property(j => j.IsDeleted).IsRequired();
            builder.HasOne<JobAdvert>(j => j.JobAdvert).WithMany(j => j.JobSeekersFavoriteJobAdverts).HasForeignKey(j => j.JobAdvertId);
            builder.HasOne<JobSeeker>(j => j.JobSeeker).WithMany(j => j.JobSeekersFavoriteJobAdverts).HasForeignKey(j => j.JobSeekerId);
            builder.ToTable("JobSeekersFavoriteJobAdverts");
        }
    }
}
