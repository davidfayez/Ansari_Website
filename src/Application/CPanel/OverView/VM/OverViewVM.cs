using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Offer.Queries.GetAll;

namespace Ansari_Website.Application.CPanel.OverView.VM;
public class OverViewVM : AuditableEntity, IMapFrom<DB.OverView>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<OverViewVM, DB.OverView>()
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
}
