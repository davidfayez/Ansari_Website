using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Domain.Entities.CPanel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ansari_Website.Infrastructure.Configurations;
public class AnswerTypeConfiguration : IEntityTypeConfiguration<AnswerType>
{
    public void Configure(EntityTypeBuilder<AnswerType> builder)
    {
        builder.ToTable(nameof(AnswerType));

        builder.Property(s => s.Id).UseIdentityColumn();

        builder.Property(s => s.Name)
               .IsRequired()
               .HasMaxLength(50);
    }
}
