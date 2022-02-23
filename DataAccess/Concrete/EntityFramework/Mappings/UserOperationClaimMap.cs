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
    public class UserOperationClaimMap : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.HasOne<User>(u => u.User).WithMany(u => u.UserOperationClaims).HasForeignKey(u => u.UserId);
            builder.HasOne<OperationClaim>(u => u.OperationClaim).WithMany(o => o.UserOperationClaims).HasForeignKey(u => u.OperationClaimId);
            builder.ToTable("UserOperationClaims");
        }
    }
}
