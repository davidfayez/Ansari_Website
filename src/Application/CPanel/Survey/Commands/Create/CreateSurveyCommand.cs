using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Survey.Commands.Create;

namespace Ansari_Website.Application.CPanel.Survey.Commands.Create;
public class CreateUpdateSurveyCommand : AuditableEntity, IRequest<bool>, IMapFrom<DB.Survey>
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public int AnswerId { get; set; }
    public int? Rate { get; set; }
    public bool IsViewed { get; set; }
    public string? Feedback { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<DB.Survey, CreateUpdateSurveyCommand>()
               .ReverseMap();

    }
}

public class CreateUpdateSurveyCommandHandler : IRequestHandler<CreateUpdateSurveyCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CreateUpdateSurveyCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(CreateUpdateSurveyCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var Survey = _mapper.Map<DB.Survey>(request);

            if (request.Id > 0)
                _applicationDbContext.Surveys.Update(Survey);
            else
                _applicationDbContext.Surveys.Add(Survey);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            return await Task.FromResult(false);
        }

    }
}
