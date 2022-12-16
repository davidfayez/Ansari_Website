using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Domain.Entities.CPanel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Ansari_Website.Infrastructure.Configurations;
public class SiteInfoConfiguration : IEntityTypeConfiguration<SiteInfo>
{
    public void Configure(EntityTypeBuilder<SiteInfo> builder)
    {
        builder.ToTable(nameof(SiteInfo));
        builder.Property(s => s.Id).UseIdentityColumn();
    }
}
