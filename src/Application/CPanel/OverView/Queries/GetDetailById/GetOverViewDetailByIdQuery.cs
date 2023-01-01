using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansari_Website.Application.CPanel.OverView.Queries.GetDetailById;
public class GetOverViewDetailByIdQuery : IRequest<DB.OverViewDetail>
{
    public int Id { get; set; }
}

public class GetOverViewDetailByIdQueryHandler : IRequestHandler<GetOverViewDetailByIdQuery, DB.OverViewDetail>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetOverViewDetailByIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public Task<DB.OverViewDetail> Handle(GetOverViewDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var OverViewDetail = _applicationDbContext.OverViewDetails.FirstOrDefault(s => s.Id == request.Id);

        if (OverViewDetail != null)
            return Task.FromResult(OverViewDetail);

        else
            return Task.FromResult(new DB.OverViewDetail());

    }


}