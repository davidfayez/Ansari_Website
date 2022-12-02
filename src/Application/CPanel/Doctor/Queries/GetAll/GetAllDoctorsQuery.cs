using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansari_Website.Application.CPanel.Doctor.Queries.GetAll;
public class GetAllDoctorsQuery : IRequest<List<DoctorVM>>
{

}

public class GetAllDoctorsQueryHandler : IRequestHandler<GetAllDoctorsQuery, List<DoctorVM>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public GetAllDoctorsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public Task<List<DoctorVM>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
    {
        var Doctors = _applicationDbContext.Doctors.Where(s => !s.IsDeleted);

        var DoctorVMs = _mapper.Map<List<DoctorVM>>(Doctors.ToList());
        return Task.FromResult(DoctorVMs);
    }
}

