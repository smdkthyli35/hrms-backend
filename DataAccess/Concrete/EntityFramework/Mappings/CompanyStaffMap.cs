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
    public class CompanyStaffMap : IEntityTypeConfiguration<CompanyStaff>
    {
        public void Configure(EntityTypeBuilder<CompanyStaff> builder)
        {
            builder.HasKey(c => c.UserId);
            builder.Property(c => c.UserId).ValueGeneratedOnAdd();
            builder.Property(c => c.FirstName).HasMaxLength(50);
            builder.Property(c => c.FirstName).IsRequired();
            builder.Property(c => c.LastName).HasMaxLength(50);
            builder.Property(c => c.LastName).IsRequired();
            builder.Property(c => c.CreatedByName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.ModifiedByName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.ModifiedDate).IsRequired();
            builder.Property(c => c.CreatedDate).IsRequired();
            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.ToTable("CompanyStaffs");
        }
    }
}
