using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.OverView.Queries.GetAll;
using Ansari_Website.Application.CPanel.OverView.VM;

namespace Ansari_Website.Application.CPanel.OverView.Queries.GetAll;
public class GetAllOverViewsQuery : IRequest<List<OverViewVM>>
{

}

public class GetAllOverViewsQueryHandler : IRequestHandler<GetAllOverViewsQuery, List<OverViewVM>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public GetAllOverViewsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public Task<List<OverViewVM>> Handle(GetAllOverViewsQuery request, CancellationToken cancellationToken)
    {
        var OverViews = _applicationDbContext.OverViews.Where(s => !s.IsDeleted);

        var OverViewVMs = _mapper.Map<List<OverViewVM>>(OverViews.ToList());
        return Task.FromResult(OverViewVMs);
    }
}