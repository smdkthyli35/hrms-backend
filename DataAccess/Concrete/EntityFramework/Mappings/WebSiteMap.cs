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
    public class WebSiteMap : IEntityTypeConfiguration<WebSite>
    {
        public void Configure(EntityTypeBuilder<WebSite> builder)
        {
            builder.HasKey(w => w.Id);
            builder.Property(w => w.Id).ValueGeneratedOnAdd();
            builder.Property(w => w.Name).HasMaxLength(50);
            builder.Property(w => w.Name).IsRequired();
            builder.Property(w => w.CreatedByName).IsRequired().HasMaxLength(50);
            builder.Property(w => w.ModifiedByName).IsRequired().HasMaxLength(50);
            builder.Property(w => w.ModifiedDate).IsRequired();
            builder.Property(w => w.CreatedDate).IsRequired();
            builder.Property(w => w.IsActive).IsRequired();
            builder.Property(w => w.IsDeleted).IsRequired();
            builder.ToTable("WebSites");
        }
    }
}
