using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Doctor.Commands.Create;
using Ansari_Website.Application.CPanel.Offer.Queries.GetAll;
using Ansari_Website.Domain.Enums;

namespace Ansari_Website.Application.CPanel.Offer.Queries.GetAll;
public class GetAllOffersQuery : IRequest<List<OfferVM>>
{
    public int LangId { get; set; }
}

public class GetAllOffersQueryHandler : IRequestHandler<GetAllOffersQuery, List<OfferVM>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public GetAllOffersQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public Task<List<OfferVM>> Handle(GetAllOffersQuery request, CancellationToken cancellationToken)
    {
        var Offers = _applicationDbContext.Offers
                                          .Include(s=>s.OfferDetails)
                                          .Where(s => !s.IsDeleted);

        //var OfferVMs = _mapper.Map<List<OfferVM>>(Offers.ToList());
        var OfferVMs = Offers.Select(s => new OfferVM
        {
            Id = s.Id,
            AltImage = s.AltImage,
            TitleAr = s.TitleAr,
            TitleEn = s.TitleEn,
            Title = (request.LangId == (int)ELanguages.AR) ? s.TitleAr : s.TitleEn,
            Description = (request.LangId == (int)ELanguages.AR) ? s.DescriptionAr : s.DescriptionEn,
            DescriptionAr = s.DescriptionAr,
            DescriptionEn = s.DescriptionEn,
            ImageUrl = s.ImageUrl,
            PriceAfter = s.PriceAfter,
            Order = s.Order,
            PriceBefore = s.PriceBefore,
            OfferDetailVMs = s.OfferDetails.Select(x=>new OfferDetailVM
            {
                Id= x.Id,
                TitleAr= x.TitleAr,
                TitleEn = x.TitleEn,
                OfferId = x.OfferId,
                Order=x.Order,
                Title = (request.LangId == (int)ELanguages.AR) ? x.TitleAr : x.TitleEn,
            }).ToList()
        }).ToList();
        return Task.FromResult(OfferVMs);
    }
}