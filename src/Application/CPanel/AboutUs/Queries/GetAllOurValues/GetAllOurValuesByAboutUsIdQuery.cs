using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Offer.Queries.GetAll;

namespace Ansari_Website.Application.CPanel.AboutUs.Queries.GetAllOurValues;
public class GetAllOurValuesByAboutUsIdQuery : IRequest<List<DB.OurValue>>
{
    public int Id { get; set; }
}

public class GetAllOurValuesByAboutUsIdQueryHandler : IRequestHandler<GetAllOurValuesByAboutUsIdQuery, List<DB.OurValue>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllOurValuesByAboutUsIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public Task<List<DB.OurValue>> Handle(GetAllOurValuesByAboutUsIdQuery request, CancellationToken cancellationToken)
    {
        var AboutUs = _applicationDbContext.AboutUs.Include(s => s.OurValues).FirstOrDefault(s => s.Id == request.Id && !s.IsDeleted);

        if (AboutUs != null)
            return Task.FromResult(AboutUs.OurValues.ToList());

        else
            return Task.FromResult(new List<DB.OurValue>());

    }


}

