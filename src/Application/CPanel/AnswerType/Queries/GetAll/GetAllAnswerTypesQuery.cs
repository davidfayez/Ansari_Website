using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.AnswerType.Queries.GetAll;

namespace Ansari_Website.Application.CPanel.AnswerType.Queries.GetAll;
public class GetAllAnswerTypesQuery : IRequest<List<AnswerTypeVM>>
{

}

public class GetAllAnswerTypesQueryHandler : IRequestHandler<GetAllAnswerTypesQuery, List<AnswerTypeVM>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public GetAllAnswerTypesQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public Task<List<AnswerTypeVM>> Handle(GetAllAnswerTypesQuery request, CancellationToken cancellationToken)
    {
        var AnswerTypes = _applicationDbContext.AnswerTypes.Where(s => !s.IsDeleted);

        var AnswerTypeVMs = _mapper.Map<List<AnswerTypeVM>>(AnswerTypes.ToList());
        return Task.FromResult(AnswerTypeVMs);
    }
}

