using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.OverView.Commands.Delete;

namespace Ansari_Website.Application.CPanel.OverView.Commands.DeleteDetail;
public class DeleteOverViewDetailsByIdCommand : IRequest<bool>, IMapFrom<DB.OverViewDetail>
{
    public int Id { get; set; }
}

public class DeleteOverViewDetailsByIdCommandHandler : IRequestHandler<DeleteOverViewDetailsByIdCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public DeleteOverViewDetailsByIdCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(DeleteOverViewDetailsByIdCommand request, CancellationToken cancellationToken)
    {
        if (request.Id > 0)
        {
            var OverViewDetail = _applicationDbContext.OverViewDetails.Find(request.Id);
            if (OverViewDetail != null)
            {
                //OverViewDetail.IsDeleted = true;
                _applicationDbContext.OverViewDetails.Remove(OverViewDetail);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return await Task.FromResult(true);
            }
        }
        return await Task.FromResult(false);
    }
}