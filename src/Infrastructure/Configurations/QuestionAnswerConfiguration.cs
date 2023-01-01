using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Domain.Entities.CPanel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ansari_Website.Infrastructure.Configurations;
public class QuestionAnswerConfiguration : IEntityTypeConfiguration<QuestionAnswer>
{
    public void Configure(EntityTypeBuilder<QuestionAnswer> builder)
    {
        builder.ToTable(nameof(QuestionAnswer));

        builder.Property(s => s.Id).UseIdentityColumn();

        //builder.HasKey(bc => new { bc.QuestionId, bc.AnswerId });
       
        builder.HasOne(bc => bc.Question)
               .WithMany(b => b.QuestionAnswers)
               .HasForeignKey(bc => bc.QuestionId)
               .OnDelete(DeleteBehavior.NoAction); ;

        builder.HasOne(bc => bc.Answer)
               .WithMany(c => c.QuestionAnswers)
               .HasForeignKey(bc => bc.AnswerId)
               .OnDelete(DeleteBehavior.NoAction); ;
    }
}
