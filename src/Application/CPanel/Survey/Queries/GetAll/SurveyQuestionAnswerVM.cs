using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.OverView.VM;

namespace Ansari_Website.Application.CPanel.Survey.Queries.GetAll;
public class SurveyQuestionAnswerVM : IMapFrom<DB.SurveyQuestionAnswer>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<SurveyQuestionAnswerVM, DB.SurveyQuestionAnswer>()
               .ReverseMap();
    }
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public int AnswerId { get; set; }
    public int SurveyId { get; set; }
    public string QuestionNameAr { get; set; }
    public string QuestionNameEn { get; set; }
    public string AnswerNameAr { get; set; }
    public string AnswerNameEn { get; set; }
}
