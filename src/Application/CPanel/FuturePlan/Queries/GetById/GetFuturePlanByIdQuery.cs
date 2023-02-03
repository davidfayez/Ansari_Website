using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.FuturePlan.Queries.GetById;

namespace Ansari_Website.Application.CPanel.FuturePlan.Queries.GetById;
public class GetFuturePlanByIdQuery : IRequest<DB.FuturePlan>
{
    public int Id { get; set; }
}

public class GetFuturePlanByIdQueryHandler : IRequestHandler<GetFuturePlanByIdQuery, DB.FuturePlan>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetFuturePlanByIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public Task<DB.FuturePlan> Handle(GetFuturePlanByIdQuery request, CancellationToken cancellationToken)
    {
        var FuturePlan = _applicationDbContext.FuturePlans.FirstOrDefault(s => s.Id == request.Id && !s.IsDeleted);

        if (FuturePlan != null)
            return Task.FromResult(FuturePlan);

        else
            return Task.FromResult(new DB.FuturePlan());

    }


}

