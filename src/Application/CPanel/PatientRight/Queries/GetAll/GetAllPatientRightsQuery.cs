using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.PatientRight.Queries.GetAll;
using Ansari_Website.Application.CPanel.PatientRight.VM;

namespace Ansari_Website.Application.CPanel.PatientRight.Queries.GetAll;
public class GetAllPatientRightsQuery : IRequest<List<PatientRightVM>>
{

}

public class GetAllPatientRightsQueryHandler : IRequestHandler<GetAllPatientRightsQuery, List<PatientRightVM>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public GetAllPatientRightsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public Task<List<PatientRightVM>> Handle(GetAllPatientRightsQuery request, CancellationToken cancellationToken)
    {
        var PatientRights = _applicationDbContext.PatientRights.Where(s => !s.IsDeleted);

        var PatientRightVMs = _mapper.Map<List<PatientRightVM>>(PatientRights.ToList());
        return Task.FromResult(PatientRightVMs);
    }
}