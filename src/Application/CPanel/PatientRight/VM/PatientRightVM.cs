using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Domain.Entities.CPanel;

namespace Ansari_Website.Application.CPanel.PatientRight.VM;
public class PatientRightVM : AuditableEntity, IMapFrom<DB.PatientRight>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<PatientRightVM, DB.PatientRight>()
               .ReverseMap();
    }
    public int Id { get; set; }
    public int? Order { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    public string? ImageUrl { get; set; }
    public string? AltImage { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public List<PatientRightDetailVM> PatientRightDetailVMs { get; set; }

}
