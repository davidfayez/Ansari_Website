using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Testiminie.Queries.GetById;

namespace Ansari_Website.Application.CPanel.Testiminie.Queries.GetById;
public class GetTestiminieByIdQuery : IRequest<DB.Testiminie>
{
    public int Id { get; set; }
}

public class GetTestiminieByIdQueryHandler : IRequestHandler<GetTestiminieByIdQuery, DB.Testiminie>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetTestiminieByIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public Task<DB.Testiminie> Handle(GetTestiminieByIdQuery request, CancellationToken cancellationToken)
    {
        var Testiminie = _applicationDbContext.Testiminies.Include(s => s.TestiminieDetails).FirstOrDefault(s => s.Id == request.Id && !s.IsDeleted);

        if (Testiminie != null)
            return Task.FromResult(Testiminie);

        else
            return Task.FromResult(new DB.Testiminie());

    }


}