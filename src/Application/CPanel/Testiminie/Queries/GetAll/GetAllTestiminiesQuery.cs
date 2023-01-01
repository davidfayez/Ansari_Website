using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Testiminie.Queries.GetAll;
using Ansari_Website.Application.CPanel.Testiminie.VM;

namespace Ansari_Website.Application.CPanel.Testiminie.Queries.GetAll;
public class GetAllTestiminiesQuery : IRequest<List<TestiminieVM>>
{

}

public class GetAllTestiminiesQueryHandler : IRequestHandler<GetAllTestiminiesQuery, List<TestiminieVM>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public GetAllTestiminiesQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public Task<List<TestiminieVM>> Handle(GetAllTestiminiesQuery request, CancellationToken cancellationToken)
    {
        var Testiminies = _applicationDbContext.Testiminies.Where(s => !s.IsDeleted);

        var TestiminieVMs = _mapper.Map<List<TestiminieVM>>(Testiminies.ToList());
        return Task.FromResult(TestiminieVMs);
    }
}