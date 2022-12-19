using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Domain.Entities.CPanel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ansari_Website.Infrastructure.Configurations;
public class PatientRightDetailConfiguration : IEntityTypeConfiguration<PatientRightDetail>
{
    public void Configure(EntityTypeBuilder<PatientRightDetail> builder)
    {
        builder.ToTable(nameof(PatientRightDetail));

        builder.Property(s => s.Id).UseIdentityColumn();

        builder.Property(s => s.TitleAr)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(s => s.TitleEn)
               .IsRequired()
               .HasMaxLength(50);

        builder.HasOne(s => s.PatientRight)
               .WithMany(s => s.PatientRightDetails)
               .HasForeignKey(s => s.PatientRightId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
