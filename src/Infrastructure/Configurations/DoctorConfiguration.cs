using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Domain.Entities.CPanel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ansari_Website.Infrastructure.Configurations;
public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.ToTable(nameof(Doctor));

        builder.Property(s => s.Id).UseIdentityColumn();

        builder.Property(s => s.NameAr)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(s => s.NameEn)
               .IsRequired()
               .HasMaxLength(50);

        builder.HasOne(s => s.Department)
               .WithMany(s => s.Doctors)
               .HasForeignKey(s => s.DepartmentId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
