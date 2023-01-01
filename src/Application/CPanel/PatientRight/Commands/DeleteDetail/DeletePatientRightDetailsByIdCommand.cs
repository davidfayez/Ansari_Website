using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.PatientRight.Commands.DeleteDetail;

namespace Ansari_Website.Application.CPanel.PatientRight.Commands.DeleteDetail;
public class DeletePatientRightDetailsByIdCommand : IRequest<bool>, IMapFrom<DB.PatientRightDetail>
{
    public int Id { get; set; }
}


public class DeletePatientRightDetailsByIdCommandHandler : IRequestHandler<DeletePatientRightDetailsByIdCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public DeletePatientRightDetailsByIdCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(DeletePatientRightDetailsByIdCommand request, CancellationToken cancellationToken)
    {
        if (request.Id > 0)
        {
            var PatientRightDetail = _applicationDbContext.PatientRightDetails.Find(request.Id);
            if (PatientRightDetail != null)
            {
                //PatientRightDetail.IsDeleted = true;
                _applicationDbContext.PatientRightDetails.Remove(PatientRightDetail);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return await Task.FromResult(true);
            }
        }
        return await Task.FromResult(false);
    }
}
