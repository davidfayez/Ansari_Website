using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Answer.Queries.GetAll;

namespace Ansari_Website.Application.CPanel.AboutUs.Queries.GetAll;
public class OurValueVM : IMapFrom<DB.OurValue>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<OurValueVM, DB.OurValue>()
               .ReverseMap();
    }

    public int Id { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public string? IconName { get; set; }
}
