using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Partner.Commands.Delete;

namespace Ansari_Website.Application.CPanel.Partner.Commands.Delete;
public class DeletePartnerCommand : IRequest<bool>, IMapFrom<DB.Partner>
{
    public int Id { get; set; }
}

public class DeletePartnerCommandHandler : IRequestHandler<DeletePartnerCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public DeletePartnerCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(DeletePartnerCommand request, CancellationToken cancellationToken)
    {
        if (request.Id > 0)
        {
            var Partner = _applicationDbContext.Partners.Find(request.Id);
            if (Partner != null)
            {
                Partner.IsDeleted = true;
                _applicationDbContext.Partners.Update(Partner);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return await Task.FromResult(true);
            }
        }
        return await Task.FromResult(false);
    }
}
