using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.OverView.Commands.Create;

namespace Ansari_Website.Application.CPanel.OverView.Commands.CreateDetail;
public class CreateUpdateOverViewDetailCommand : IRequest<bool>, IMapFrom<DB.OverViewDetail>
{
    public int Id { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public int Value { get; set; }
    public int OverViewId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DB.OverViewDetail, CreateUpdateOverViewDetailCommand>()
               .ReverseMap();
    }
}

public class CreateUpdateOverViewDetailCommandHandler : IRequestHandler<CreateUpdateOverViewDetailCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CreateUpdateOverViewDetailCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(CreateUpdateOverViewDetailCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var OverView = _mapper.Map<DB.OverViewDetail>(request);

            if (request.Id > 0)
                _applicationDbContext.OverViewDetails.Update(OverView);
            else
                _applicationDbContext.OverViewDetails.Add(OverView);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            return await Task.FromResult(false);
        }

    }
}

