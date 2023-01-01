using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.OverView.VM;

namespace Ansari_Website.Application.CPanel.Testiminie.VM;
public class TestiminieDetailVM : IMapFrom<DB.TestiminieDetail>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<TestiminieDetailVM, DB.TestiminieDetail>()
               .ReverseMap();
    }
    public int Id { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public string? ImageUrl { get; set; }
    public int TestiminieId { get; set; }
}
