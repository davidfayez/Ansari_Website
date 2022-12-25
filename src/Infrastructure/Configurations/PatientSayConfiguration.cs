using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Ansari_Website.Domain.Entities.CPanel;

namespace Ansari_Website.Infrastructure.Configurations;
public class PatientSayConfiguration : IEntityTypeConfiguration<PatientSay>
{
    public void Configure(EntityTypeBuilder<PatientSay> builder)
    {
        builder.ToTable(nameof(PatientSay));

        builder.Property(s => s.Id).UseIdentityColumn();

        builder.Property(s => s.TitleAr)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(s => s.TitleEn)
               .IsRequired()
               .HasMaxLength(50);
    }
}
