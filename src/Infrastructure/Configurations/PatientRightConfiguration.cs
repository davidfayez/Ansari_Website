using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Domain.Entities.CPanel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ansari_Website.Infrastructure.Configurations;
public class PatientRightConfiguration : IEntityTypeConfiguration<PatientRight>
{
    public void Configure(EntityTypeBuilder<PatientRight> builder)
    {
        builder.ToTable(nameof(PatientRight));

        builder.Property(s => s.Id).UseIdentityColumn();

        builder.Property(s => s.TitleAr)
               .IsRequired()
               .HasMaxLength(150);

        builder.Property(s => s.TitleEn)
               .IsRequired()
               .HasMaxLength(150);
    }
}
