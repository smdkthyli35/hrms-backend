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
    public class JobSeekerCvWebSiteMap : IEntityTypeConfiguration<JobSeekerCvWebSite>
    {
        public void Configure(EntityTypeBuilder<JobSeekerCvWebSite> builder)
        {
            builder.HasKey(j => j.Id);
            builder.Property(j => j.Id).ValueGeneratedOnAdd();
            builder.Property(j => j.Address).HasMaxLength(50);
            builder.Property(j => j.Address).IsRequired();
            builder.HasOne<JobSeekerCv>(j => j.JobSeekerCv).WithMany(j => j.JobSeekerCvWebSites).HasForeignKey(j => j.JobSeekerCvId);
            builder.HasOne<WebSite>(j => j.WebSite).WithMany(j => j.JobSeekerCvWebSites).HasForeignKey(j => j.WebSiteId);
            builder.ToTable("JobSeekerCvWebSites");
        }
    }
}
