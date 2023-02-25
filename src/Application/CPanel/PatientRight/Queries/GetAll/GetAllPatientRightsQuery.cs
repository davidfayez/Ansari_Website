using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.PatientRight.Queries.GetAll;
using Ansari_Website.Application.CPanel.PatientRight.VM;
using Ansari_Website.Domain.Enums;

namespace Ansari_Website.Application.CPanel.PatientRight.Queries.GetAll;
public class GetAllPatientRightsQuery : IRequest<PatientRightVM>
{
    public int LangId { get; set; }
}

public class GetAllPatientRightsQueryHandler : IRequestHandler<GetAllPatientRightsQuery, PatientRightVM>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public GetAllPatientRightsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public Task<PatientRightVM> Handle(GetAllPatientRightsQuery request, CancellationToken cancellationToken)
    {
        var PatientRight = _applicationDbContext.PatientRights
                                    .Include(s=>s.PatientRightDetails)
                                    .Where(s => !s.IsDeleted);

        //var PatientRightVMs = _mapper.Map<List<PatientRightVM>>(PatientRights.ToList());
        var PatientRightVM = PatientRight.Select(s=> new PatientRightVM
        {
            Id= s.Id,
            AltImage= s.AltImage,
            TitleAr = s.TitleAr,
            TitleEn= s.TitleEn,
            DescriptionAr= s.DescriptionAr,
            DescriptionEn= s.DescriptionEn,
            ImageUrl= s.ImageUrl,
            Order= s.Order,
            Title = (request.LangId == (int)ELanguages.AR) ? s.TitleAr : s.TitleEn,
            Description = (request.LangId == (int)ELanguages.AR) ? s.DescriptionAr : s.DescriptionEn,
            PatientRightDetailVMs = s.PatientRightDetails.Select(x=>new PatientRightDetailVM
            {
                Id = x.Id,
                TitleAr=x.TitleAr,
                PatientRightId=x.PatientRightId,
                TitleEn=x.TitleEn,
                Title = (request.LangId == (int)ELanguages.AR) ? x.TitleAr : x.TitleEn,
            }).ToList() 
        }).FirstOrDefault();
        return Task.FromResult(PatientRightVM);
    }
}