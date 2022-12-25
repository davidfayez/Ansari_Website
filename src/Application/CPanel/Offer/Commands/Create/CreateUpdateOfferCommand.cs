using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Doctor.Commands.Create;
using Ansari_Website.Application.CPanel.Offer.Commands.Create;
using Ansari_Website.Domain.Entities.CPanel;
using Microsoft.AspNetCore.Http;

namespace Ansari_Website.Application.CPanel.Offer.Commands.Create;
public class CreateUpdateOfferCommand :  AuditableEntity, IRequest<bool>, IMapFrom<DB.Offer>
{

    public int Id { get; set; }
    public int? Order { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    public string? ImageUrl { get; set; }
    public string? AltImage { get; set; }
    public decimal PriceBefore { get; set; }
    public decimal PriceAfter { get; set; }
    public IFormFile OfferImage { get; set; }
    public List<OfferDetailVM> OfferDetailVMs { get; set; } = new();

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DB.Offer, CreateUpdateOfferCommand>()
                .ForMember(des => des.OfferDetailVMs, opt => opt.MapFrom(src => src.OfferDetails))
               .ReverseMap();

        profile.CreateMap<DB.OfferDetail, OfferDetailVM>()
               .ReverseMap();
    }
}

public class CreateUpdateOfferCommandHandler : IRequestHandler<CreateUpdateOfferCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CreateUpdateOfferCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(CreateUpdateOfferCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var Offer = _mapper.Map<DB.Offer>(request);

            if (request.Id > 0)
                _applicationDbContext.Offers.Update(Offer);
            else
                _applicationDbContext.Offers.Add(Offer);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            return await Task.FromResult(false);
        }

    }
}
