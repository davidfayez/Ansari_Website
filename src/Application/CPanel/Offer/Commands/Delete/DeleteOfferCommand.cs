using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Offer.Commands.Delete;

namespace Ansari_Website.Application.CPanel.Offer.Commands.Delete;
public class DeleteOfferCommand : IRequest<bool>, IMapFrom<DB.Offer>
{
    public int Id { get; set; }
}

public class DeleteOfferCommandHandler : IRequestHandler<DeleteOfferCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public DeleteOfferCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(DeleteOfferCommand request, CancellationToken cancellationToken)
    {
        if (request.Id > 0)
        {
            var Offer = _applicationDbContext.Offers.Find(request.Id);
            if (Offer != null)
            {
                Offer.IsDeleted = true;
                _applicationDbContext.Offers.Update(Offer);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return await Task.FromResult(true);
            }
        }
        return await Task.FromResult(false);
    }
}

