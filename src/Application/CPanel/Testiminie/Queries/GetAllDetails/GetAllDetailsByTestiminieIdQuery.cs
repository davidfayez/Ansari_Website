using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Testiminie.Queries.GetAllDetails;

namespace Ansari_Website.Application.CPanel.Testiminie.Queries.GetAllDetails;
public class GetAllDetailsByTestiminieIdQuery : IRequest<List<DB.TestiminieDetail>>
{
    public int Id { get; set; }
}

public class GetAllDetailsByTestiminieIdQueryHandler : IRequestHandler<GetAllDetailsByTestiminieIdQuery, List<DB.TestiminieDetail>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllDetailsByTestiminieIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public Task<List<DB.TestiminieDetail>> Handle(GetAllDetailsByTestiminieIdQuery request, CancellationToken cancellationToken)
    {
        var Testiminie = _applicationDbContext.Testiminies.Include(s => s.TestiminieDetails).FirstOrDefault(s => s.Id == request.Id && !s.IsDeleted);

        if (Testiminie != null)
            return Task.FromResult(Testiminie.TestiminieDetails.ToList());

        else
            return Task.FromResult(new List<DB.TestiminieDetail>());

    }


}