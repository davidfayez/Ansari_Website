using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.FuturePlan.Commands.Delete;

namespace Ansari_Website.Application.CPanel.FuturePlan.Commands.Delete;
public class DeleteFuturePlanCommand : IRequest<bool>, IMapFrom<DB.FuturePlan>
{
    public int Id { get; set; }
}

public class DeleteFuturePlanCommandHandler : IRequestHandler<DeleteFuturePlanCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public DeleteFuturePlanCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(DeleteFuturePlanCommand request, CancellationToken cancellationToken)
    {
        if (request.Id > 0)
        {
            var FuturePlan = _applicationDbContext.FuturePlans.Find(request.Id);
            if (FuturePlan != null)
            {
                FuturePlan.IsDeleted = true;
                _applicationDbContext.FuturePlans.Update(FuturePlan);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return await Task.FromResult(true);
            }
        }
        return await Task.FromResult(false);
    }
}
