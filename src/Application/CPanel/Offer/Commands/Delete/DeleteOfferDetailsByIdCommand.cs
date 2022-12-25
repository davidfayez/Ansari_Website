using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Doctor.Commands.Delete;

namespace Ansari_Website.Application.CPanel.Offer.Commands.Delete;
public class DeleteOfferDetailsByIdCommand : IRequest<bool>, IMapFrom<DB.OfferDetail>
{
    public int Id { get; set; }
}


public class DeleteOfferDetailsByIdCommandHandler : IRequestHandler<DeleteOfferDetailsByIdCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public DeleteOfferDetailsByIdCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(DeleteOfferDetailsByIdCommand request, CancellationToken cancellationToken)
    {
        if (request.Id > 0)
        {
            var OfferDetail = _applicationDbContext.OfferDetails.Find(request.Id);
            if (OfferDetail != null)
            {
                //OfferDetail.IsDeleted = true;
                _applicationDbContext.OfferDetails.Remove(OfferDetail);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return await Task.FromResult(true);
            }
        }
        return await Task.FromResult(false);
    }
}

