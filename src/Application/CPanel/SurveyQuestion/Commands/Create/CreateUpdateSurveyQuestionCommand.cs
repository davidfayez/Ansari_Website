using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.SurveyQuestion.Commands.Create;

namespace Ansari_Website.Application.CPanel.SurveyQuestion.Commands.Create;
public class CreateUpdateSurveyQuestionCommand : AuditableEntity, IRequest<bool>, IMapFrom<DB.SurveyQuestion>
{
    public int Id { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public int Order { get; set; }
    public int AnswerTypeId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DB.SurveyQuestion, CreateUpdateSurveyQuestionCommand>()
               .ReverseMap();
    }
}

public class CreateUpdateSurveyQuestionCommandHandler : IRequestHandler<CreateUpdateSurveyQuestionCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CreateUpdateSurveyQuestionCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(CreateUpdateSurveyQuestionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var SurveyQuestion = _mapper.Map<DB.SurveyQuestion>(request);

            if (request.Id > 0)
                _applicationDbContext.SurveyQuestions.Update(SurveyQuestion);
            else
                _applicationDbContext.SurveyQuestions.Add(SurveyQuestion);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            return await Task.FromResult(false);
        }

    }
}

