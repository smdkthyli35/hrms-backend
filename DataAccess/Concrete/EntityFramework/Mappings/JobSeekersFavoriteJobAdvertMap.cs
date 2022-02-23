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
            builder.HasOne<JobAdvert>(j => j.JobAdvert).WithMany(j => j.JobSeekersFavoriteJobAdverts).HasForeignKey(j => j.JobAdvertId);
            builder.HasOne<JobSeeker>(j => j.JobSeeker).WithMany(j => j.JobSeekersFavoriteJobAdverts).HasForeignKey(j => j.JobSeekerId);
            builder.ToTable("JobSeekersFavoriteJobAdverts");
        }
    }
}
