using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Department.Queries.GetAll;
using Ansari_Website.Application.CPanel.Doctor.Commands.Create;
using Ansari_Website.Domain.Entities.CPanel;

namespace Ansari_Website.Application.CPanel.Offer.Queries.GetAll;
public class OfferVM : AuditableEntity, IMapFrom<DB.Offer>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<OfferVM, DB.Offer>()
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
    public decimal PriceBefore { get; set; }
    public decimal PriceAfter { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public List<OfferDetailVM> OfferDetailVMs { get; set; }

}

public class OfferDetailsVM : IMapFrom<DB.OfferDetail>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<OfferDetailsVM, DB.OfferDetail>()
               .ReverseMap();
    }
    public int Id { get; set; }
    public int? Order { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public int OfferId { get; set; }
}

