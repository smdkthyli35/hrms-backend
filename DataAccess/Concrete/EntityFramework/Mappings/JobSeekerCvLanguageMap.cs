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
    public class JobSeekerCvLanguageMap : IEntityTypeConfiguration<JobSeekerCvLanguage>
    {
        public void Configure(EntityTypeBuilder<JobSeekerCvLanguage> builder)
        {
            builder.HasKey(j => j.Id);
            builder.Property(j => j.Id).ValueGeneratedOnAdd();
            builder.Property(j => j.Level).IsRequired();
            builder.HasOne<JobSeekerCv>(j => j.JobSeekerCv).WithMany(j => j.JobSeekerCvLanguages).HasForeignKey(j => j.JobSeekerCvId);
            builder.HasOne<Language>(j => j.Language).WithMany(l => l.JobSeekerCvLanguages).HasForeignKey(j => j.LanguageId);
            builder.ToTable("JobSeekerCvLanguages");
        }
    }
}
