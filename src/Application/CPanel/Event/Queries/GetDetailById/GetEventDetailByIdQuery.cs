using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Event.Queries.GetDetailById;

namespace Ansari_Website.Application.CPanel.Event.Queries.GetDetailById;
public class GetEventDetailByIdQuery : IRequest<DB.EventDetail>
{
    public int Id { get; set; }
}

public class GetEventDetailByIdQueryHandler : IRequestHandler<GetEventDetailByIdQuery, DB.EventDetail>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetEventDetailByIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public Task<DB.EventDetail> Handle(GetEventDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var EventDetail = _applicationDbContext.EventDetails.FirstOrDefault(s => s.Id == request.Id);

        if (EventDetail != null)
            return Task.FromResult(EventDetail);

        else
            return Task.FromResult(new DB.EventDetail());

    }


}
