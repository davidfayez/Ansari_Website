using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Domain.Entities.CPanel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Ansari_Website.Infrastructure.Configurations;
public class SurveyQuestionAnswerConfiguration : IEntityTypeConfiguration<SurveyQuestionAnswer>
{
    public void Configure(EntityTypeBuilder<SurveyQuestionAnswer> builder)
    {
        builder.ToTable(nameof(SurveyQuestionAnswer));

        builder.Property(s => s.Id).UseIdentityColumn();

        builder.Property(s => s.QuestionId)
               .IsRequired();

        builder.Property(s => s.AnswerId)
               .IsRequired();

        builder.HasOne(s => s.Survey)
               .WithMany(s => s.SurveyQuestionAnswers)
               .HasForeignKey(s => s.SurveyId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
