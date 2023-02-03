using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Slider.Queries.GetAll;

namespace Ansari_Website.Application.CPanel.Slider.Queries.GetAll;
public class GetAllSlidersQuery : IRequest<List<SliderVM>>
{

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

        var SliderVMs = _mapper.Map<List<SliderVM>>(Sliders.ToList());
        return Task.FromResult(SliderVMs);
    }
}