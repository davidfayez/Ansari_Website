using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Ansari_Website.Domain.Entities.CPanel;

namespace Ansari_Website.Infrastructure.Configurations;
public class SurveyConfiguration : IEntityTypeConfiguration<Survey>
{
    public void Configure(EntityTypeBuilder<Survey> builder)
    {
        builder.ToTable(nameof(Survey));

        builder.Property(s => s.Id).UseIdentityColumn();

        builder.Property(s => s.Feedback)
               .HasMaxLength(750);

        builder.Property(s => s.Rate)
               .HasMaxLength(5);
    }
}
