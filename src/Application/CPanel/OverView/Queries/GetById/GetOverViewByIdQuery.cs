using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.OverView.Queries.GetById;

namespace Ansari_Website.Application.CPanel.OverView.Queries.GetById;
public class GetOverViewByIdQuery : IRequest<DB.OverView>
{
    public int Id { get; set; }
}

public class GetOverViewByIdQueryHandler : IRequestHandler<GetOverViewByIdQuery, DB.OverView>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetOverViewByIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public Task<DB.OverView> Handle(GetOverViewByIdQuery request, CancellationToken cancellationToken)
    {
        var OverView = _applicationDbContext.OverViews.Include(s => s.OverViewDetails).FirstOrDefault(s => s.Id == request.Id && !s.IsDeleted);

        if (OverView != null)
            return Task.FromResult(OverView);

        else
            return Task.FromResult(new DB.OverView());

    }


}