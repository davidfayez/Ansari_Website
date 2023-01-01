using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.OverView.Queries.GetAll;

namespace Ansari_Website.Application.CPanel.OverView.Queries.GetAllDetails;
public class GetAllDetailsByOverViewIdQuery : IRequest<List<DB.OverViewDetail>>
{
    public int Id { get; set; }
}

public class GetAllDetailsByOverViewIdQueryHandler : IRequestHandler<GetAllDetailsByOverViewIdQuery, List<DB.OverViewDetail>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllDetailsByOverViewIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public Task<List<DB.OverViewDetail>> Handle(GetAllDetailsByOverViewIdQuery request, CancellationToken cancellationToken)
    {
        var OverView = _applicationDbContext.OverViews.Include(s => s.OverViewDetails).FirstOrDefault(s => s.Id == request.Id && !s.IsDeleted);

        if (OverView != null)
            return Task.FromResult(OverView.OverViewDetails.ToList());

        else
            return Task.FromResult(new List<DB.OverViewDetail>());

    }


}