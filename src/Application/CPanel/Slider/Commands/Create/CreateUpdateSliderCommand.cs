using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Slider.Commands.Create;
using Microsoft.AspNetCore.Http;

namespace Ansari_Website.Application.CPanel.Slider.Commands.Create;
public class CreateUpdateSliderCommand : AuditableEntity, IRequest<bool>, IMapFrom<DB.Slider>
{
    public int Id { get; set; }
    public int? Order { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    public string? ImageUrl { get; set; }
    public string? AltImage { get; set; }
    public IFormFile SliderImage { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<DB.Slider, CreateUpdateSliderCommand>()
               .ReverseMap();
    }
}

public class CreateUpdateSliderCommandHandler : IRequestHandler<CreateUpdateSliderCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CreateUpdateSliderCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(CreateUpdateSliderCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var Slider = _mapper.Map<DB.Slider>(request);

            if (request.Id > 0)
                _applicationDbContext.Sliders.Update(Slider);
            else
                _applicationDbContext.Sliders.Add(Slider);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            return await Task.FromResult(false);
        }

    }
}
