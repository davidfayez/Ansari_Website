using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.Common.Interfaces;
using Ansari_Website.Application.CPanel.Doctor.Commands.Create;

namespace Ansari_Website.Application.CPanel.Offer.Commands.Create;
public class CreateUpdateOfferDetailCommand : IRequest<bool>, IMapFrom<DB.OfferDetail>
{
    public int Id { get; set; }
    public int? Order { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public int OfferId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DB.OfferDetail, CreateUpdateOfferDetailCommand>()
               .ReverseMap();
    }
}

public class CreateUpdateOfferDetailCommandHandler : IRequestHandler<CreateUpdateOfferDetailCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CreateUpdateOfferDetailCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(CreateUpdateOfferDetailCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var Offer = _mapper.Map<DB.OfferDetail>(request);

            if (request.Id > 0)
                _applicationDbContext.OfferDetails.Update(Offer);
            else
                _applicationDbContext.OfferDetails.Add(Offer);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            return await Task.FromResult(false);
        }

    }
}
