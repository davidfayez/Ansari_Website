using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Answer.Queries.GetAll;

namespace Ansari_Website.Application.CPanel.FuturePlan.Queries.GetAll;
public class FuturePlanVM : AuditableEntity, IMapFrom<DB.FuturePlan>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<FuturePlanVM, DB.FuturePlan>()
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
}
