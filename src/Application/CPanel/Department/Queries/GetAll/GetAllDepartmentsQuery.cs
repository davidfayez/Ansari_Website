using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Department.Queries.GetAll;

namespace Ansari_Website.Application.CPanel.Department.Queries.GetAll;
public class GetAllDepartmentsQuery : IRequest<List<DepartmentVM>>
{

}

public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, List<DepartmentVM>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public GetAllDepartmentsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public Task<List<DepartmentVM>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
    {
        var Departments = _applicationDbContext.Departments.Where(s => !s.IsDeleted);

        var DepartmentVMs = _mapper.Map<List<DepartmentVM>>(Departments.ToList());
        return Task.FromResult(DepartmentVMs);
    }
}

