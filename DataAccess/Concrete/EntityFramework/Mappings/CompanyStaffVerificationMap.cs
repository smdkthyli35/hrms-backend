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
    public class CompanyStaffVerificationMap : IEntityTypeConfiguration<CompanyStaffVerification>
    {
        public void Configure(EntityTypeBuilder<CompanyStaffVerification> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.IsAproved).IsRequired();
            builder.HasOne<User>(c => c.User).WithMany(u => u.CompanyStaffVerifications).HasForeignKey(c => c.UserId);
            builder.ToTable("CompanyStaffVerifications");
        }
    }
}
