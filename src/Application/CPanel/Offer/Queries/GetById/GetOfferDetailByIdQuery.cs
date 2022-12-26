using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansari_Website.Application.CPanel.OfferDetail.Queries.GetById;
public class GetOfferDetailByIdQuery : IRequest<DB.OfferDetail>
{
    public int Id { get; set; }
}

public class GetOfferDetailByIdQueryHandler : IRequestHandler<GetOfferDetailByIdQuery, DB.OfferDetail>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetOfferDetailByIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public Task<DB.OfferDetail> Handle(GetOfferDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var OfferDetail = _applicationDbContext.OfferDetails.FirstOrDefault(s => s.Id == request.Id);

        if (OfferDetail != null)
            return Task.FromResult(OfferDetail);

        else
            return Task.FromResult(new DB.OfferDetail());

    }


}
