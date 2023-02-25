using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Offer.Queries.GetAll;
using Ansari_Website.Domain.Entities.CPanel;

namespace Ansari_Website.Application.CPanel.OverView.VM;
public class OverViewVM : AuditableEntity, IMapFrom<DB.OverView>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<OverViewVM, DB.OverView>()
                .ForMember(des => des.OverViewDetails, opt => opt.MapFrom(src => src.OverViewDetailVMs))
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
    public List<OverViewDetailVM> OverViewDetailVMs { get; set; }

}
