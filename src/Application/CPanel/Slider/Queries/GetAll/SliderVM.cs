using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Answer.Queries.GetAll;

namespace Ansari_Website.Application.CPanel.Slider.Queries.GetAll;
public class SliderVM : AuditableEntity, IMapFrom<DB.Slider>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<SliderVM, DB.Slider>()
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
