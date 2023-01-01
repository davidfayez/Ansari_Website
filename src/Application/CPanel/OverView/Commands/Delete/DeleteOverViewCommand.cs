using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.OverView.Commands.Delete;

namespace Ansari_Website.Application.CPanel.OverView.Commands.Delete;
public class DeleteOverViewCommand : IRequest<bool>, IMapFrom<DB.OverView>
{
    public int Id { get; set; }
}

public class DeleteOverViewCommandHandler : IRequestHandler<DeleteOverViewCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public DeleteOverViewCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(DeleteOverViewCommand request, CancellationToken cancellationToken)
    {
        if (request.Id > 0)
        {
            var OverView = _applicationDbContext.OverViews.Find(request.Id);
            if (OverView != null)
            {
                OverView.IsDeleted = true;
                _applicationDbContext.OverViews.Update(OverView);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return await Task.FromResult(true);
            }
        }
        return await Task.FromResult(false);
    }
}
