using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Testiminie.Queries.GetAll;
using Ansari_Website.Application.CPanel.Testiminie.VM;
using Ansari_Website.Domain.Enums;

namespace Ansari_Website.Application.CPanel.Testiminie.Queries.GetAll;
public class GetAllTestiminiesQuery : IRequest<TestiminieVM>
{
    public int LangId { get; set; }
}

public class GetAllTestiminiesQueryHandler : IRequestHandler<GetAllTestiminiesQuery, TestiminieVM>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public GetAllTestiminiesQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public Task<TestiminieVM> Handle(GetAllTestiminiesQuery request, CancellationToken cancellationToken)
    {
        var Testiminies = _applicationDbContext.Testiminies
                            .Include(s=>s.TestiminieDetails)
                            .Where(s => !s.IsDeleted);

        //var TestiminieVMs = _mapper.Map<List<TestiminieVM>>(Testiminies.ToList());
        var TestiminieVMs = Testiminies.Select(s => new TestiminieVM
        {
            Id= s.Id,
            TitleAr = s.TitleAr,
            TitleEn= s.TitleEn,
            Title = (request.LangId == (int)ELanguages.AR) ? s.TitleAr : s.TitleEn,
            Description = (request.LangId == (int)ELanguages.AR) ? s.DescriptionAr : s.DescriptionEn,
            DescriptionAr = s.DescriptionAr,
            DescriptionEn = s.DescriptionEn,
            ImageUrl = s.ImageUrl,  
            TestiminieDetailVMs = s.TestiminieDetails.Select(x=>new TestiminieDetailVM
            {
                Id= x.Id,
                TitleAr = x.TitleAr,
                TitleEn = x.TitleEn,
                ImageUrl = x.ImageUrl,
                TestiminieId = x.TestiminieId,
                Title = (request.LangId == (int)ELanguages.AR) ? s.TitleAr : s.TitleEn,
            }).ToList(),
        }).FirstOrDefault();
        return Task.FromResult(TestiminieVMs);
    }
}