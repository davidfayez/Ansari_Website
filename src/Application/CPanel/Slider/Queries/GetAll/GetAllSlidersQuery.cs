using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Slider.Queries.GetAll;
using Ansari_Website.Domain.Enums;

namespace Ansari_Website.Application.CPanel.Slider.Queries.GetAll;
public class GetAllSlidersQuery : IRequest<List<SliderVM>>
{
    public int LangId { get; set; }
}

public class GetAllSlidersQueryHandler : IRequestHandler<GetAllSlidersQuery, List<SliderVM>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public GetAllSlidersQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public Task<List<SliderVM>> Handle(GetAllSlidersQuery request, CancellationToken cancellationToken)
    {
        var Sliders = _applicationDbContext.Sliders.Where(s => !s.IsDeleted);

        //var SliderVMs = _mapper.Map<List<SliderVM>>(Sliders.ToList());
        var SliderVMs = Sliders.Select(s=>new SliderVM
        {
            Id= s.Id,
            DescriptionEn = s.DescriptionEn,
            DescriptionAr = s.DescriptionAr,
            AltImage= s.AltImage,
            ImageUrl= s.ImageUrl,
            TitleAr= s.TitleAr,
            TitleEn= s.TitleEn,
            Order= s.Order,
            Title = (request.LangId == (int)ELanguages.AR) ? s.TitleAr : s.TitleEn,
            Description = (request.LangId == (int)ELanguages.AR) ? s.DescriptionAr : s.DescriptionEn,
        }).ToList();
        return Task.FromResult(SliderVMs);
    }
}