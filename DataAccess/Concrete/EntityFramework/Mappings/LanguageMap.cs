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
    public class LanguageMap : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id).ValueGeneratedOnAdd();
            builder.Property(l => l.Name).HasMaxLength(50);
            builder.Property(l => l.Name).IsRequired();
            builder.Property(l => l.CreatedByName).IsRequired().HasMaxLength(50);
            builder.Property(l => l.ModifiedByName).IsRequired().HasMaxLength(50);
            builder.Property(l => l.ModifiedDate).IsRequired();
            builder.Property(l => l.CreatedDate).IsRequired();
            builder.Property(l => l.IsActive).IsRequired();
            builder.Property(l => l.IsDeleted).IsRequired();
            builder.ToTable("Languages");
        }
    }
}
