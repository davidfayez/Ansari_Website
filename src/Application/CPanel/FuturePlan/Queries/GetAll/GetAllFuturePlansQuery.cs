using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Event.VM;
using Ansari_Website.Application.CPanel.FuturePlan.Queries.GetAll;
using Ansari_Website.Domain.Enums;

namespace Ansari_Website.Application.CPanel.FuturePlan.Queries.GetAll;
public class GetAllFuturePlansQuery : IRequest<List<FuturePlanVM>>
{
    public int LangId { get; set; }
}

public class GetAllFuturePlansQueryHandler : IRequestHandler<GetAllFuturePlansQuery, List<FuturePlanVM>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public GetAllFuturePlansQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public Task<List<FuturePlanVM>> Handle(GetAllFuturePlansQuery request, CancellationToken cancellationToken)
    {
        var FuturePlans = _applicationDbContext.FuturePlans.Where(s => !s.IsDeleted);

        //var FuturePlanVMs = _mapper.Map<List<FuturePlanVM>>(FuturePlans.ToList());
        var FuturePlanVMs = FuturePlans.Select(s => new FuturePlanVM
        {
            Id = s.Id,
            DescriptionAr = s.DescriptionAr,
            DescriptionEn = s.DescriptionEn,
            TitleAr = s.TitleAr,
            TitleEn = s.TitleEn,
            ImageUrl = s.ImageUrl,
            Order= s.Order,
            AltImage = s.AltImage,
            Title = (request.LangId == (int)ELanguages.AR) ? s.TitleAr : s.TitleEn,
            Description = (request.LangId == (int)ELanguages.AR) ? s.DescriptionAr : s.DescriptionEn,
        }).ToList();
        return Task.FromResult(FuturePlanVMs);
    }
}