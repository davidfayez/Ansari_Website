using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Event.Commands.Create;
using Ansari_Website.Application.CPanel.Event.VM;
using Microsoft.AspNetCore.Http;

namespace Ansari_Website.Application.CPanel.Event.Commands.Create;
public class CreateUpdateEventCommand : AuditableEntity, IRequest<bool>, IMapFrom<DB.Event>
{
    public int Id { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    public string? ImageUrl { get; set; }
    public IFormFile EventImage { get; set; }
    public List<EventDetailVM> EventDetailVMs { get; set; } = new();

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DB.Event, CreateUpdateEventCommand>()
                .ForMember(des => des.EventDetailVMs, opt => opt.MapFrom(src => src.EventDetails))
               .ReverseMap();

        profile.CreateMap<DB.EventDetail, EventDetailVM>()
               .ReverseMap();
    }
}

public class CreateUpdateEventCommandHandler : IRequestHandler<CreateUpdateEventCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CreateUpdateEventCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(CreateUpdateEventCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var Event = _mapper.Map<DB.Event>(request);

            if (request.Id > 0)
                _applicationDbContext.Events.Update(Event);
            else
                _applicationDbContext.Events.Add(Event);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            return await Task.FromResult(false);
        }

    }
}

