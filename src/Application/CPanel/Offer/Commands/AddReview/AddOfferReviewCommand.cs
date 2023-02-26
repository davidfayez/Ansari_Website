using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Complaint.Commands.IsSeen;

namespace Ansari_Website.Application.CPanel.Offer.Commands.AddReview;
public class AddOfferReviewCommand : IRequest<int>
{
    public int Id { get; set; }

}

public class AddOfferReviewCommandHandler : IRequestHandler<AddOfferReviewCommand, int>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public AddOfferReviewCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<int> Handle(AddOfferReviewCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var Offer = _applicationDbContext.Offers.Find(request.Id);
            if (Offer != null)
            {
                Offer.ReviewsNo += 1;
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return await Task.FromResult(Offer.ReviewsNo);
            }
            return await Task.FromResult(0);
        }
        catch (Exception ex)
        {
            return await Task.FromResult(0);
        }

    }
}
