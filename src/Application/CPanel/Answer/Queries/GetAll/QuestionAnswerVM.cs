using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansari_Website.Application.CPanel.Answer.Queries.GetAll;
public class QuestionAnswerVM : IMapFrom<DB.QuestionAnswer>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<DB.QuestionAnswer, QuestionAnswerVM>()
               .ForMember(des => des.AnswerAr, opt => opt.MapFrom(src => src.Answer.NameAr))
               .ForMember(des => des.AnswerEn, opt => opt.MapFrom(src => src.Answer.NameEn))
               .ReverseMap();

    }
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public int AnswerId { get; set; }
    public string AnswerAr { get; set; }
    public string AnswerEn { get; set; }
}
