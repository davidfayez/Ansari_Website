using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Domain.Entities.CPanel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ansari_Website.Infrastructure.Configurations;
public class SurveyQuestionConfiguration : IEntityTypeConfiguration<SurveyQuestion>
{
    public void Configure(EntityTypeBuilder<SurveyQuestion> builder)
    {
        builder.ToTable(nameof(SurveyQuestion));
        builder.Property(s => s.Id).UseIdentityColumn();

        builder.Property(s => s.TitleAr)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(s => s.TitleEn)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(s => s.Order)
               .IsRequired();

        builder.Property(s => s.AnswerTypeId)
               .HasMaxLength(50);

        builder.HasOne(s => s.AnswerType)
               .WithMany(s => s.SurveyQuestions)
               .HasForeignKey(s => s.AnswerTypeId)
               .OnDelete(DeleteBehavior.NoAction);


    }
}
