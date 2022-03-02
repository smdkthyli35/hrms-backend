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
    public class EmployerMap : IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<Employer> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.CompanyName).HasMaxLength(100);
            builder.Property(e => e.CompanyName).IsRequired();
            builder.Property(e => e.WebSite).HasMaxLength(50);
            builder.Property(e => e.WebSite).IsRequired();
            builder.Property(e => e.CorporateEmail).HasMaxLength(50);
            builder.Property(e => e.CorporateEmail).IsRequired();
            builder.Property(e => e.Phone).HasMaxLength(13);
            builder.Property(e => e.Phone).IsRequired();
            builder.ToTable("Employers");
        }
    }
}
