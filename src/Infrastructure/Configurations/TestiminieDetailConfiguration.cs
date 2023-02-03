using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Domain.Entities.CPanel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ansari_Website.Infrastructure.Configurations;
public class TestiminieDetailConfiguration : IEntityTypeConfiguration<TestiminieDetail>
{
    public void Configure(EntityTypeBuilder<TestiminieDetail> builder)
    {
        builder.ToTable(nameof(TestiminieDetail));

        builder.Property(s => s.Id).UseIdentityColumn();

        builder.Property(s => s.TitleAr)
               .IsRequired()
               .HasMaxLength(500);

        builder.Property(s => s.TitleEn)
               .IsRequired()
               .HasMaxLength(500);

        builder.HasOne(s => s.Testiminie)
               .WithMany(s => s.TestiminieDetails)
               .HasForeignKey(s => s.TestiminieId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
