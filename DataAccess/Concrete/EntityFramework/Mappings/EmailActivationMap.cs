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
    public class EmailActivationMap : IEntityTypeConfiguration<EmailActivation>
    {
        public void Configure(EntityTypeBuilder<EmailActivation> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.ActivationCode).HasMaxLength(20);
            builder.Property(e => e.ActivationCode).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(40);
            builder.Property(e => e.Email).IsRequired();
            builder.Property(e => e.ExpirationDate).IsRequired();
            builder.Property(e => e.CreatedByName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.ModifiedByName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.ModifiedDate).IsRequired();
            builder.Property(e => e.CreatedDate).IsRequired();
            builder.Property(e => e.IsActive).IsRequired();
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.ToTable("EmailActivations");
        }
    }
}
