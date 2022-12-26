using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansari_Website.Application.CPanel.Offer.Commands.Create;
public class CreateUpdateOfferDetailCommand : IRequest<bool>, IMapFrom<DB.OfferDetail>
{
    public int Id { get; set; }
    public int? Order { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public int OfferId { get; set; }
}
