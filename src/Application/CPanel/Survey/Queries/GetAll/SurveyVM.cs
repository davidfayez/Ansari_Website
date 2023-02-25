using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Complaint.Queries.GetAll;
using Ansari_Website.Domain.Entities.CPanel;

namespace Ansari_Website.Application.CPanel.Survey.Queries.GetAll;
public class SurveyVM :AuditableEntity, IMapFrom<DB.Survey>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<DB.Survey, SurveyVM>()
                .ForMember(des => des.SurveyQuestionAnswerVMs, opt => opt.MapFrom(src => src.SurveyQuestionAnswers))
               .ReverseMap();

        profile.CreateMap<DB.SurveyQuestionAnswer, SurveyQuestionAnswerVM>()
                .ForMember(des => des.AnswerNameAr, opt => opt.MapFrom(src => src.Answer.NameAr))
                .ForMember(des => des.AnswerNameEn, opt => opt.MapFrom(src => src.Answer.NameEn))
                .ForMember(des => des.QuestionNameAr, opt => opt.MapFrom(src => src.Question.TitleAr))
                .ForMember(des => des.QuestionNameEn, opt => opt.MapFrom(src => src.Question.TitleEn))
               .ReverseMap();
    }
    public int Id { get; set; }
    public int? Rate { get; set; }
    public string? Feedback { get; set; }
    public bool IsViewed { get; set; }
    public List<SurveyQuestionAnswerVM> SurveyQuestionAnswerVMs { get; set; }
    
}
