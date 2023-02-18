using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Survey.Commands.View;

namespace Ansari_Website.Application.CPanel.Survey.Commands.View;
public class ViewSurveyCommand : IRequest<bool>, IMapFrom<DB.Survey>
{
    public int Id { get; set; }
}

public class ViewSurveyCommandHandler : IRequestHandler<ViewSurveyCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public ViewSurveyCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }

    public async Task<bool> Handle(ViewSurveyCommand request, CancellationToken cancellationToken)
    {
        if (request.Id > 0)
        {
            var Survey = _applicationDbContext.Surveys.Find(request.Id);
            if (Survey != null)
            {
                Survey.IsViewed = true;
                _applicationDbContext.Surveys.Update(Survey);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return await Task.FromResult(true);
            }
        }
        return await Task.FromResult(false);
    }
}
