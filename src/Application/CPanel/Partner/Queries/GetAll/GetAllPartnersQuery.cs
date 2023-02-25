using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Partner.Queries.GetAll;
using Ansari_Website.Domain.Enums;

namespace Ansari_Website.Application.CPanel.Partner.Queries.GetAll;
public class GetAllPartnersQuery : IRequest<List<PartnerVM>>
{
    public int LangId { get; set; }
}

public class GetAllPartnersQueryHandler : IRequestHandler<GetAllPartnersQuery, List<PartnerVM>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public GetAllPartnersQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public Task<List<PartnerVM>> Handle(GetAllPartnersQuery request, CancellationToken cancellationToken)
    {
        var Partners = _applicationDbContext.Partners.Where(s => !s.IsDeleted);

        //var PartnerVMs = _mapper.Map<List<PartnerVM>>(Partners.ToList());
        var PartnerVMs = Partners.Select(s=>new PartnerVM
        {
            Id= s.Id,
            TitleAr = s.TitleAr,
            TitleEn= s.TitleEn,
            ImageUrl = s.ImageUrl,
            DescriptionEn= s.DescriptionEn,
            DescriptionAr = s.DescriptionAr,
            Title = (request.LangId == (int)ELanguages.AR) ? s.TitleAr: s.TitleEn,
            Description = (request.LangId == (int)ELanguages.AR) ? s.DescriptionAr: s.DescriptionEn,
        }).ToList();
        return Task.FromResult(PartnerVMs);
    }
}
