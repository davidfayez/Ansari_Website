using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansari_Website.Application.CPanel.PatientRight.VM;
public class PatientRightDetailVM : IMapFrom<DB.PatientRightDetail>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<PatientRightDetailVM, DB.PatientRightDetail>()
               .ReverseMap();
    }
    public int Id { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public string? Title { get; set; }
    public int PatientRightId { get; set; }
}
