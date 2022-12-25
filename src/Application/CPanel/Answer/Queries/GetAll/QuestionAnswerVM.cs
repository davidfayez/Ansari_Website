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
        profile.CreateMap<QuestionAnswerVM, DB.QuestionAnswer>()
               .ReverseMap();
    }
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public int AnswerId { get; set; }
}
