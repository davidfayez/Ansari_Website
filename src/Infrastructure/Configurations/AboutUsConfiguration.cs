using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Domain.Entities.CPanel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ansari_Website.Infrastructure.Configurations;
public class AboutUsConfiguration : IEntityTypeConfiguration<AboutUs>
{
    public void Configure(EntityTypeBuilder<AboutUs> builder)
    {
        builder.ToTable(nameof(AboutUs));

        builder.Property(s => s.Id).UseIdentityColumn();

        //builder.Property(s => s.ComplaintCode)
        //       .IsRequired()
        //       .HasMaxLength(30);
    }
}
