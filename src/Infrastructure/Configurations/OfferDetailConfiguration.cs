using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Domain.Entities.CPanel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ansari_Website.Infrastructure.Configurations;
public class OfferDetailConfiguration : IEntityTypeConfiguration<OfferDetail>
{
    public void Configure(EntityTypeBuilder<OfferDetail> builder)
    {
        builder.ToTable(nameof(OfferDetail));

        builder.Property(s => s.Id).UseIdentityColumn();

        builder.Property(s => s.TitleAr)
               .IsRequired()
               .HasMaxLength(500);

        builder.Property(s => s.TitleEn)
               .IsRequired()
               .HasMaxLength(500);

        builder.HasOne(s => s.Offer)
               .WithMany(s => s.OfferDetails)
               .HasForeignKey(s => s.OfferId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
