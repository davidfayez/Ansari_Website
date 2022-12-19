using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.SurveyQuestion.Commands.Delete;

namespace Ansari_Website.Application.CPanel.SurveyQuestion.Commands.Delete;
public class DeleteSurveyQuestionCommand : IRequest<bool>, IMapFrom<DB.Question>
{
    public int Id { get; set; }
}


public class DeleteSurveyQuestionCommandHandler : IRequestHandler<DeleteSurveyQuestionCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public DeleteSurveyQuestionCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(DeleteSurveyQuestionCommand request, CancellationToken cancellationToken)
    {
        if (request.Id > 0)
        {
            var SurveyQuestion = _applicationDbContext.SurveyQuestions.Find(request.Id);
            if (SurveyQuestion != null)
            {
                SurveyQuestion.IsDeleted = true;
                _applicationDbContext.SurveyQuestions.Update(SurveyQuestion);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return await Task.FromResult(true);
            }
        }
        return await Task.FromResult(false);
    }
}
