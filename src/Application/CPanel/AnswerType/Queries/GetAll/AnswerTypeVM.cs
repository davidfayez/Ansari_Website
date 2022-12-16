using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.SurveyQuestion.Queries.GetAll;

namespace Ansari_Website.Application.CPanel.AnswerType.Queries.GetAll;
public class AnswerTypeVM : AuditableEntity, IMapFrom<DB.AnswerType>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<AnswerTypeVM, DB.AnswerType>()
               .ReverseMap();
    }

    public int Id { get; set; }
    public string Name { get; set; }
}
