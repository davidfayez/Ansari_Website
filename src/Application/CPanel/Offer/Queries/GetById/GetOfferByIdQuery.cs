using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Offer.Queries.GetById;

namespace Ansari_Website.Application.CPanel.Offer.Queries.GetById;
public class GetOfferByIdQuery : IRequest<DB.Offer>
{
    public int Id { get; set; }
}

public class GetOfferByIdQueryHandler : IRequestHandler<GetOfferByIdQuery, DB.Offer>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetOfferByIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public Task<DB.Offer> Handle(GetOfferByIdQuery request, CancellationToken cancellationToken)
    {
        var Offer = _applicationDbContext.Offers.Include(s=>s.OfferDetails).FirstOrDefault(s => s.Id == request.Id && !s.IsDeleted);

        if (Offer != null)
            return Task.FromResult(Offer);

        else
            return Task.FromResult(new DB.Offer());

    }


}

