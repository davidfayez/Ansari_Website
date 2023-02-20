using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Department.Queries.GetById;
using Ansari_Website.Domain.Enums;

namespace Ansari_Website.Application.CPanel.Department.Queries.GetByType;
public class GetDepartmentByTypeQuery : IRequest<List<DB.Department>>
{
    public Speciality Type { get; set; }
}


public class GetDepartmentByTypeQueryHandler : IRequestHandler<GetDepartmentByTypeQuery, List<DB.Department>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetDepartmentByTypeQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public Task<List<DB.Department>> Handle(GetDepartmentByTypeQuery request, CancellationToken cancellationToken)
    {
        var Departments = _applicationDbContext.Departments.Where(s => s.Speciality == request.Type && !s.IsDeleted).ToList();

        if (Departments != null)
            return Task.FromResult(Departments);

        else
            return Task.FromResult(new List<DB.Department>());

    }


}


