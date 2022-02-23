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
    public class JobAdvertMap : IEntityTypeConfiguration<JobAdvert>
    {
        public void Configure(EntityTypeBuilder<JobAdvert> builder)
        {
            builder.HasKey(j => j.Id);
            builder.Property(j => j.Id).ValueGeneratedOnAdd();
            builder.Property(j => j.Description).HasMaxLength(500);
            builder.Property(j => j.Description).IsRequired();
            builder.Property(j => j.NumberOfOpenPositions).IsRequired();
            builder.HasOne<City>(j => j.City).WithMany(c => c.JobAdverts).HasForeignKey(j => j.CityId);
            builder.HasOne<Employer>(j => j.Employer).WithMany(e => e.JobAdverts).HasForeignKey(j => j.EmployerId);
            builder.HasOne<JobPosition>(j => j.JobPosition).WithMany(j => j.JobAdverts).HasForeignKey(j => j.JobPositionId);
            builder.HasOne<WorkingTime>(j => j.WorkingTime).WithMany(w => w.JobAdverts).HasForeignKey(j => j.WorkingTimeId);
            builder.HasOne<WorkingType>(j => j.WorkingType).WithMany(w => w.JobAdverts).HasForeignKey(j => j.WorkingTypeId);
            builder.ToTable("JobAdverts");
        }
    }
}
