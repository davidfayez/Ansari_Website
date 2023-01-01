using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Offer.Queries.GetAll;

namespace Ansari_Website.Application.CPanel.OverView.VM;
public class OverViewDetailVM : IMapFrom<DB.OverViewDetail>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<OverViewDetailVM, DB.OverViewDetail>()
               .ReverseMap();
    }
    public int Id { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public int Value { get; set; }
    public int OverViewId { get; set; }
}
