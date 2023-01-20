using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Testiminie.Commands.Create;
using Ansari_Website.Application.CPanel.Testiminie.VM;
using Microsoft.AspNetCore.Http;

namespace Ansari_Website.Application.CPanel.Testiminie.Commands.Create;
public class CreateUpdateTestiminieCommand : AuditableEntity, IRequest<int>, IMapFrom<DB.Testiminie>
{
    public int Id { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    public string? ImageUrl { get; set; }

    public IFormFile TestiminieImage { get; set; }
    public List<TestiminieDetailVM> TestiminieDetailVMs { get; set; } = new();

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DB.Testiminie, CreateUpdateTestiminieCommand>()
                .ForMember(des => des.TestiminieDetailVMs, opt => opt.MapFrom(src => src.TestiminieDetails))
               .ReverseMap();

        profile.CreateMap<DB.TestiminieDetail, TestiminieDetailVM>()
               .ReverseMap();
    }
}

public class CreateUpdateTestiminieCommandHandler : IRequestHandler<CreateUpdateTestiminieCommand, int>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CreateUpdateTestiminieCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateUpdateTestiminieCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var Testiminie = _mapper.Map<DB.Testiminie>(request);

            if (request.Id > 0)
                _applicationDbContext.Testiminies.Update(Testiminie);
            else
                _applicationDbContext.Testiminies.Add(Testiminie);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(Testiminie.Id);
        }
        catch (Exception ex)
        {
            return await Task.FromResult(0);
        }

    }
}

