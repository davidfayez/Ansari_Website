using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Answer.Queries.GetAll;
using Ansari_Website.Domain.Entities.CPanel;

namespace Ansari_Website.Application.CPanel.Question.Queries.GetAll;
public class QuestionVM : AuditableEntity, IMapFrom<DB.Question>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<DB.Question,QuestionVM>()
                .ForMember(des => des.QuestionAnswerVMs, opt => opt.MapFrom(src => src.QuestionAnswers))
               .ReverseMap();
    }

    public int Id { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public int? Order { get; set; }
    public List<QuestionAnswerVM> QuestionAnswerVMs { get; set; }
}
