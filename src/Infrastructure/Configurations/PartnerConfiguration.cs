using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Domain.Entities.CPanel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Ansari_Website.Infrastructure.Configurations;
public class PartnerConfiguration : IEntityTypeConfiguration<Partner>
{
    public void Configure(EntityTypeBuilder<Partner> builder)
    {
        builder.ToTable(nameof(Partner));

        builder.Property(s => s.Id).UseIdentityColumn();

        builder.Property(s => s.TitleAr)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(s => s.TitleEn)
               .IsRequired()
               .HasMaxLength(50);
    }
}
