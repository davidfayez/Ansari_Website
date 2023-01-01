using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansari_Website.Application.CPanel.AboutUs.Queries.GetOurValueById;
public class GetOurValueByIdQuery : IRequest<DB.OurValue>
{
    public int Id { get; set; }
}

public class GetOurValueByIdQueryHandler : IRequestHandler<GetOurValueByIdQuery, DB.OurValue>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetOurValueByIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public Task<DB.OurValue> Handle(GetOurValueByIdQuery request, CancellationToken cancellationToken)
    {
        var OurValue = _applicationDbContext.OurValues.FirstOrDefault(s => s.Id == request.Id);

        if (OurValue != null)
            return Task.FromResult(OurValue);

        else
            return Task.FromResult(new DB.OurValue());

    }


}

