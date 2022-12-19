using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Answer.Queries.GetAll;

namespace Ansari_Website.Application.CPanel.SurveyQuestion.Queries.GetAll;
public class SurveyQuestionVM : AuditableEntity, IMapFrom<DB.Question>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<SurveyQuestionVM, DB.Question>()
               .ReverseMap();
    }

    public int Id { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public int Order { get; set; }
    public int AnswerTypeId { get; set; }
}
