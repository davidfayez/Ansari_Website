using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Doctor.Commands.Create;

namespace Ansari_Website.Application.CPanel.Doctor.Commands.Create;
public class CreateUpdateDoctorCommand : AuditableEntity, IRequest<bool>, IMapFrom<DB.Doctor>
{
    public int Id { get; set; }
    public string? NameAr { get; set; }
    public string? NameEn { get; set; }
    public int DepartmentId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateUpdateDoctorCommand, DB.Doctor>()
               .ReverseMap();
    }
}

public class CreateUpdateDoctorCommandHandler : IRequestHandler<CreateUpdateDoctorCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CreateUpdateDoctorCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(CreateUpdateDoctorCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var Doctor = _mapper.Map<DB.Doctor>(request);

            if (request.Id > 0)
                _applicationDbContext.Doctors.Update(Doctor);
            else
                _applicationDbContext.Doctors.Add(Doctor);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            return await Task.FromResult(false);
        }

    }
}

