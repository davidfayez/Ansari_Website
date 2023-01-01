using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.OverView.VM;

namespace Ansari_Website.Application.CPanel.Testiminie.VM;
public class TestiminieVM : AuditableEntity, IMapFrom<DB.Testiminie>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<TestiminieVM, DB.Testiminie>()
               .ReverseMap();
    }
    public int Id { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    public string? ImageUrl { get; set; }
}
