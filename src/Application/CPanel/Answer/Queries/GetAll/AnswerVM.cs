using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Doctor.Queries.GetAll;

namespace Ansari_Website.Application.CPanel.Answer.Queries.GetAll;
public class AnswerVM : AuditableEntity, IMapFrom<DB.Answer>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<AnswerVM, DB.Answer>()
               .ReverseMap();
    }

    public int Id { get; set; }
    public string NameAr { get; set; }
    public string NameEn { get; set; }
    public int AnswerTypeId { get; set; }
}
