using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.PatientRight.Commands.Delete;

namespace Ansari_Website.Application.CPanel.PatientRight.Commands.Delete;
public class DeletePatientRightCommand : IRequest<bool>, IMapFrom<DB.PatientRight>
{
    public int Id { get; set; }
}

public class DeletePatientRightCommandHandler : IRequestHandler<DeletePatientRightCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public DeletePatientRightCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(DeletePatientRightCommand request, CancellationToken cancellationToken)
    {
        if (request.Id > 0)
        {
            var PatientRight = _applicationDbContext.PatientRights.Find(request.Id);
            if (PatientRight != null)
            {
                PatientRight.IsDeleted = true;
                _applicationDbContext.PatientRights.Update(PatientRight);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return await Task.FromResult(true);
            }
        }
        return await Task.FromResult(false);
    }
}