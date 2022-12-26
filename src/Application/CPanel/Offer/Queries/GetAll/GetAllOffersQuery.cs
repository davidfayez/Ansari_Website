using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Offer.Queries.GetAll;

namespace Ansari_Website.Application.CPanel.Offer.Queries.GetAll;
public class GetAllOffersQuery : IRequest<List<OfferVM>>
{

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
        var Offers = _applicationDbContext.Offers.Where(s => !s.IsDeleted);

        var OfferVMs = _mapper.Map<List<OfferVM>>(Offers.ToList());
        return Task.FromResult(OfferVMs);
    }
}