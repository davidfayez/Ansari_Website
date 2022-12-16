using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Domain.Entities.CPanel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ansari_Website.Infrastructure.Configurations;
public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.ToTable(nameof(Answer));

        builder.Property(s => s.Id).UseIdentityColumn();

        builder.Property(s => s.NameAr)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(s => s.NameEn)
               .IsRequired()
               .HasMaxLength(50);

        builder.HasOne(s => s.AnswerType)
               .WithMany(s => s.Answers)
               .HasForeignKey(s => s.AnswerTypeId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
