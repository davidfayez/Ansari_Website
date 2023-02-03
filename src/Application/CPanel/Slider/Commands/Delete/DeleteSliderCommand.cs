using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Slider.Commands.Delete;

namespace Ansari_Website.Application.CPanel.Slider.Commands.Delete;
public class DeleteSliderCommand : IRequest<bool>, IMapFrom<DB.Slider>
{
    public int Id { get; set; }
}

public class DeleteSliderCommandHandler : IRequestHandler<DeleteSliderCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public DeleteSliderCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(DeleteSliderCommand request, CancellationToken cancellationToken)
    {
        if (request.Id > 0)
        {
            var Slider = _applicationDbContext.Sliders.Find(request.Id);
            if (Slider != null)
            {
                Slider.IsDeleted = true;
                _applicationDbContext.Sliders.Update(Slider);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return await Task.FromResult(true);
            }
        }
        return await Task.FromResult(false);
    }
}
