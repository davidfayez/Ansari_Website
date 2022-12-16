using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Partner.Queries.GetAll;

namespace Ansari_Website.Application.CPanel.Partner.Queries.GetAll;
public class GetAllPartnersQuery : IRequest<List<PartnerVM>>
{

}

public class GetAllPartnersQueryHandler : IRequestHandler<GetAllPartnersQuery, List<PartnerVM>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public GetAllPartnersQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public Task<List<PartnerVM>> Handle(GetAllPartnersQuery request, CancellationToken cancellationToken)
    {
        var Partners = _applicationDbContext.Partners.Where(s => !s.IsDeleted);

        var PartnerVMs = _mapper.Map<List<PartnerVM>>(Partners.ToList());
        return Task.FromResult(PartnerVMs);
    }
}
