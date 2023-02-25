using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Doctor.Queries.GetAll;

namespace Ansari_Website.Application.CPanel.Partner.Queries.GetAll;
public class PartnerVM : AuditableEntity, IMapFrom<DB.Partner>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<PartnerVM, DB.Partner>()
               .ReverseMap();
    }
    public int Id { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public string? Title { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
}
