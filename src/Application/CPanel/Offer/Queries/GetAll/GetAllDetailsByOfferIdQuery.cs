using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Offer.Queries.GetById;

namespace Ansari_Website.Application.CPanel.Offer.Queries.GetAll;
public class GetAllDetailsByOfferIdQuery : IRequest<List<DB.OfferDetail>>
{
    public int Id { get; set; }
}

public class GetAllDetailsByOfferIdQueryHandler : IRequestHandler<GetAllDetailsByOfferIdQuery, List<DB.OfferDetail>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllDetailsByOfferIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public Task<List<DB.OfferDetail>> Handle(GetAllDetailsByOfferIdQuery request, CancellationToken cancellationToken)
    {
        var Offer = _applicationDbContext.Offers.Include(s => s.OfferDetails).FirstOrDefault(s => s.Id == request.Id && !s.IsDeleted);

        if (Offer != null)
            return Task.FromResult(Offer.OfferDetails.ToList());

        else
            return Task.FromResult(new List<DB.OfferDetail>());

    }


}
