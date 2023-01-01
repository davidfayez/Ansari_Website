using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Testiminie.Commands.CreateDetail;

namespace Ansari_Website.Application.CPanel.Testiminie.Commands.CreateDetail;
public class CreateUpdateTestiminieDetailCommand : IRequest<bool>, IMapFrom<DB.TestiminieDetail>
{
    public int Id { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public string? ImageUrl { get; set; }
    public int TestiminieId { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<DB.TestiminieDetail, CreateUpdateTestiminieDetailCommand>()
               .ReverseMap();
    }
}

public class CreateUpdateTestiminieDetailCommandHandler : IRequestHandler<CreateUpdateTestiminieDetailCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CreateUpdateTestiminieDetailCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(CreateUpdateTestiminieDetailCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var Testiminie = _mapper.Map<DB.TestiminieDetail>(request);

            if (request.Id > 0)
                _applicationDbContext.TestiminieDetails.Update(Testiminie);
            else
                _applicationDbContext.TestiminieDetails.Add(Testiminie);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            return await Task.FromResult(false);
        }

    }
}

