using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Survey.Commands.Delete;

namespace Ansari_Website.Application.CPanel.Survey.Commands.Delete;
public class DeleteSurveyCommand : IRequest<bool>, IMapFrom<DB.Survey>
{
    public int Id { get; set; }
}

public class DeleteSurveyCommandHandler : IRequestHandler<DeleteSurveyCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public DeleteSurveyCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(DeleteSurveyCommand request, CancellationToken cancellationToken)
    {
        if (request.Id > 0)
        {
            var Survey = _applicationDbContext.Surveys.Find(request.Id);
            if (Survey != null)
            {
                Survey.IsDeleted = true;
                _applicationDbContext.Surveys.Update(Survey);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return await Task.FromResult(true);
            }
        }
        return await Task.FromResult(false);
    }
}