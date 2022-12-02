using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansari_Website.Application.CPanel.Doctor.Queries.GetById;
public class GetDoctorByIdQuery : IRequest<DB.Doctor>
{
    public int Id { get; set; }
}

public class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, DB.Doctor>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetDoctorByIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public Task<DB.Doctor> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
    {
        var Doctor = _applicationDbContext.Doctors.FirstOrDefault(s => s.Id == request.Id && !s.IsDeleted);

        if (Doctor != null)
            return Task.FromResult(Doctor);

        else
            return Task.FromResult(new DB.Doctor());

    }


}

