using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Domain.Entities.CPanel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ansari_Website.Infrastructure.Configurations;
public class OverViewDetailConfiguration : IEntityTypeConfiguration<OverViewDetail>
{
    public void Configure(EntityTypeBuilder<OverViewDetail> builder)
    {
        builder.ToTable(nameof(OverViewDetail));

        builder.Property(s => s.Id).UseIdentityColumn();

        builder.Property(s => s.TitleAr)
               .IsRequired()
               .HasMaxLength(500);

        builder.Property(s => s.TitleEn)
               .IsRequired()
               .HasMaxLength(500);

        builder.Property(s => s.Value)
               .IsRequired();

        builder.HasOne(s => s.OverView)
               .WithMany(s => s.OverViewDetails)
               .HasForeignKey(s => s.OverViewId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
