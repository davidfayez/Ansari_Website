using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Partner.Queries.GetById;

namespace Ansari_Website.Application.CPanel.Partner.Queries.GetById;
public class GetPartnerByIdQuery : IRequest<DB.Partner>
{
    public int Id { get; set; }
}

public class GetPartnerByIdQueryHandler : IRequestHandler<GetPartnerByIdQuery, DB.Partner>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetPartnerByIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public Task<DB.Partner> Handle(GetPartnerByIdQuery request, CancellationToken cancellationToken)
    {
        var Partner = _applicationDbContext.Partners.FirstOrDefault(s => s.Id == request.Id && !s.IsDeleted);

        if (Partner != null)
            return Task.FromResult(Partner);

        else
            return Task.FromResult(new DB.Partner());

    }


}
