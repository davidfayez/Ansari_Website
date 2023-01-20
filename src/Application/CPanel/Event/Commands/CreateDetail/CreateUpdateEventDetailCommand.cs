using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Event.Commands.CreateDetail;
using Microsoft.AspNetCore.Http;

namespace Ansari_Website.Application.CPanel.Event.Commands.CreateDetail;
public class CreateUpdateEventDetailCommand : IRequest<bool>, IMapFrom<DB.EventDetail>
{
    public int Id { get; set; }
    public int? Order { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public string? ImageUrls { get; set; }
    public int EventId { get; set; }
    public List<IFormFile> EventDetailImages { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DB.EventDetail, CreateUpdateEventDetailCommand>()
               .ReverseMap();
    }
}

public class CreateUpdateEventDetailCommandHandler : IRequestHandler<CreateUpdateEventDetailCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CreateUpdateEventDetailCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(CreateUpdateEventDetailCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var Event = _mapper.Map<DB.EventDetail>(request);

            if (request.Id > 0)
                _applicationDbContext.EventDetails.Update(Event);
            else
                _applicationDbContext.EventDetails.Add(Event);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            return await Task.FromResult(false);
        }

    }
}

