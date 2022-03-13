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
    public class JobPositionMap : IEntityTypeConfiguration<JobPosition>
    {
        public void Configure(EntityTypeBuilder<JobPosition> builder)
        {
            builder.HasKey(j => j.Id);
            builder.Property(j => j.Id).ValueGeneratedOnAdd();
            builder.Property(j => j.Title).HasMaxLength(100);
            builder.Property(j => j.Title).IsRequired();
            builder.Property(j => j.CreatedByName).IsRequired().HasMaxLength(50);
            builder.Property(j => j.ModifiedByName).IsRequired().HasMaxLength(50);
            builder.Property(j => j.ModifiedDate).IsRequired();
            builder.Property(j => j.CreatedDate).IsRequired();
            builder.Property(j => j.IsActive).IsRequired();
            builder.Property(j => j.IsDeleted).IsRequired();
            builder.ToTable("JobPositions");
        }
    }
}
