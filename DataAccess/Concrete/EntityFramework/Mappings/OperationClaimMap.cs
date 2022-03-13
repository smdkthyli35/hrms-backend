using Core.Entities.Concrete;
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
    public class OperationClaimMap : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(o => o.Name).HasMaxLength(50);
            builder.Property(o => o.Name).IsRequired();
            builder.Property(o => o.CreatedByName).IsRequired().HasMaxLength(50);
            builder.Property(o => o.ModifiedByName).IsRequired().HasMaxLength(50);
            builder.Property(o => o.ModifiedDate).IsRequired();
            builder.Property(o => o.CreatedDate).IsRequired();
            builder.Property(o => o.IsActive).IsRequired();
            builder.Property(o => o.IsDeleted).IsRequired();
            builder.ToTable("OperationClaims");
        }
    }
}
