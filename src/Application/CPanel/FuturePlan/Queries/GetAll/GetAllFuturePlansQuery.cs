using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.FuturePlan.Queries.GetAll;

namespace Ansari_Website.Application.CPanel.FuturePlan.Queries.GetAll;
public class GetAllFuturePlansQuery : IRequest<List<FuturePlanVM>>
{

}

public class GetAllFuturePlansQueryHandler : IRequestHandler<GetAllFuturePlansQuery, List<FuturePlanVM>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public GetAllFuturePlansQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public Task<List<FuturePlanVM>> Handle(GetAllFuturePlansQuery request, CancellationToken cancellationToken)
    {
        var FuturePlans = _applicationDbContext.FuturePlans.Where(s => !s.IsDeleted);

        var FuturePlanVMs = _mapper.Map<List<FuturePlanVM>>(FuturePlans.ToList());
        return Task.FromResult(FuturePlanVMs);
    }
}