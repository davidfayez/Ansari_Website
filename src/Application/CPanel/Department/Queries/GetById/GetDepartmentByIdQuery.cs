using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansari_Website.Application.CPanel.Department.Queries.GetById;
public class GetDepartmentByIdQuery : IRequest<DB.Department>
{
    public int Id { get; set; }
}

public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, DB.Department>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetDepartmentByIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public Task<DB.Department> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
    {
        var Department = _applicationDbContext.Departments.FirstOrDefault(s => s.Id == request.Id && !s.IsDeleted);

        if (Department != null)
            return Task.FromResult(Department);

        else
            return Task.FromResult(new DB.Department());

    }


}

