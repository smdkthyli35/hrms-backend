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
            builder.HasOne<User>(c => c.User).WithMany(u => u.CompanyStaffs).HasForeignKey(a => a.UserId);
            builder.ToTable("CompanyStaffs");
        }
    }
}
