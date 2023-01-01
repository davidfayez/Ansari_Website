using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Domain.Entities.CPanel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ansari_Website.Infrastructure.Configurations;
public class OurValueConfiguration : IEntityTypeConfiguration<OurValue>
{
    public void Configure(EntityTypeBuilder<OurValue> builder)
    {
        builder.ToTable(nameof(OurValue));

        builder.Property(s => s.Id).UseIdentityColumn();

        builder.Property(s => s.TitleAr)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(s => s.TitleEn)
               .IsRequired()
               .HasMaxLength(50);

        builder.HasOne(s => s.AboutUs)
               .WithMany(s => s.OurValues)
               .HasForeignKey(s => s.AboutUsId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
