using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Doctor.Commands.Create;
using Ansari_Website.Application.CPanel.OverView.Commands.Create;
using Ansari_Website.Application.CPanel.OverView.VM;
using Microsoft.AspNetCore.Http;

namespace Ansari_Website.Application.CPanel.OverView.Commands.Create;
public class CreateUpdateOverViewCommand : AuditableEntity, IRequest<bool>, IMapFrom<DB.OverView>
{
    public int Id { get; set; }
    public int? Order { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    public string? ImageUrl { get; set; }
    public string? AltImage { get; set; }
    public IFormFile OverViewImage { get; set; }
    public List<OverViewDetailVM> OverViewDetailVMs { get; set; } = new();

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DB.OverView, CreateUpdateOverViewCommand>()
                .ForMember(des => des.OverViewDetailVMs, opt => opt.MapFrom(src => src.OverViewDetails))
               .ReverseMap();

        profile.CreateMap<DB.OverViewDetail, OverViewDetailVM>()
               .ReverseMap();
    }
}

public class CreateUpdateOverViewCommandHandler : IRequestHandler<CreateUpdateOverViewCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CreateUpdateOverViewCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(CreateUpdateOverViewCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var OverView = _mapper.Map<DB.OverView>(request);

            if (request.Id > 0)
                _applicationDbContext.OverViews.Update(OverView);
            else
                _applicationDbContext.OverViews.Add(OverView);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            return await Task.FromResult(false);
        }

    }
}

