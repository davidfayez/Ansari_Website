using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Doctor.Commands.Delete;

namespace Ansari_Website.Application.CPanel.Doctor.Commands.Delete;
public class DeleteDoctorCommand : IRequest<bool>, IMapFrom<DB.Doctor>
{
    public int Id { get; set; }
}

public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public DeleteDoctorCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
    {
        if (request.Id > 0)
        {
            var Doctor = _applicationDbContext.Doctors.Find(request.Id);
            if (Doctor != null)
            {
                Doctor.IsDeleted = true;
                _applicationDbContext.Doctors.Update(Doctor);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return await Task.FromResult(true);
            }
        }
        return await Task.FromResult(false);
    }
}

