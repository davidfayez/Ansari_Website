using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Slider.Queries.GetById;

namespace Ansari_Website.Application.CPanel.Slider.Queries.GetById;
public class GetSliderByIdQuery : IRequest<DB.Slider>
{
    public int Id { get; set; }
}

public class GetSliderByIdQueryHandler : IRequestHandler<GetSliderByIdQuery, DB.Slider>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetSliderByIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public Task<DB.Slider> Handle(GetSliderByIdQuery request, CancellationToken cancellationToken)
    {
        var Slider = _applicationDbContext.Sliders.FirstOrDefault(s => s.Id == request.Id && !s.IsDeleted);

        if (Slider != null)
            return Task.FromResult(Slider);

        else
            return Task.FromResult(new DB.Slider());

    }


}
