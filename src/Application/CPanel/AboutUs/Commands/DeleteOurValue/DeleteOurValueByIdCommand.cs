using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Offer.Commands.Delete;

namespace Ansari_Website.Application.CPanel.AboutUs.Commands.DeleteOurValue;
public class DeleteOurValueByIdCommand : IRequest<bool>, IMapFrom<DB.OurValue>
{
    public int Id { get; set; }
}

public class DeleteOurValueByIdCommandHandler : IRequestHandler<DeleteOurValueByIdCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public DeleteOurValueByIdCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(DeleteOurValueByIdCommand request, CancellationToken cancellationToken)
    {
        if (request.Id > 0)
        {
            var OfferDetail = _applicationDbContext.OurValues.Find(request.Id);
            if (OfferDetail != null)
            {
                //OfferDetail.IsDeleted = true;
                _applicationDbContext.OurValues.Remove(OfferDetail);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return await Task.FromResult(true);
            }
        }
        return await Task.FromResult(false);
    }
}


