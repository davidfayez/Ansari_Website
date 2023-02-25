using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.OverView.Queries.GetAll;
using Ansari_Website.Application.CPanel.OverView.VM;
using Ansari_Website.Domain.Enums;

namespace Ansari_Website.Application.CPanel.OverView.Queries.GetAll;
public class GetAllOverViewsQuery : IRequest<OverViewVM>
{
    public int LangId { get; set; }
}

public class GetAllOverViewsQueryHandler : IRequestHandler<GetAllOverViewsQuery,OverViewVM>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public GetAllOverViewsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public Task<OverViewVM> Handle(GetAllOverViewsQuery request, CancellationToken cancellationToken)
    {
        var OverViews = _applicationDbContext.OverViews.Include(s=>s.OverViewDetails).Where(s => !s.IsDeleted);
        //var OverViewVMs = _mapper.Map<List<OverViewVM>>(OverViews.ToList());
        var OverViewVMs = OverViews.Select(s=>new OverViewVM
        {
            Id= s.Id,
            ImageUrl= s.ImageUrl,
            AltImage = s.AltImage,
            DescriptionAr = s.DescriptionAr,
            TitleAr= s.TitleAr,
            DescriptionEn= s.DescriptionEn,
            TitleEn= s.TitleEn,
            Order = s.Order,
            Title = (request.LangId == (int)ELanguages.AR) ? s.TitleAr : s.TitleEn,
            Description = (request.LangId == (int)ELanguages.AR) ? s.DescriptionAr : s.DescriptionEn,
            OverViewDetailVMs = s.OverViewDetails.Select(x=>new OverViewDetailVM
            {
                Id = x.Id,
                TitleAr= x.TitleAr,
                OverViewId= x.OverViewId,
                TitleEn= x.TitleEn,
                Value= x.Value,
                Title = (request.LangId == (int)ELanguages.AR) ? x.TitleAr : x.TitleEn,
            }).ToList()
        }).FirstOrDefault();
        return Task.FromResult(OverViewVMs);
    }
}