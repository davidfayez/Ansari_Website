using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Answer.Queries.GetAll;
using Ansari_Website.Application.CPanel.Answer.Commands.Create;
using Ansari_Website.Domain.Entities.CPanel;

namespace Ansari_Website.Application.CPanel.Answer.Commands.Create;
public class CreateUpdateAnswerCommand : AuditableEntity, IRequest<bool>, IMapFrom<DB.Answer>
{
    public int Id { get; set; }
    public string NameAr { get; set; }
    public string NameEn { get; set; }
    public int? Order { get; set; }
    public List<QuestionAnswerVM> QuestionAnswerVMs { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DB.Answer,CreateUpdateAnswerCommand>()
                .ForMember(des => des.QuestionAnswerVMs, opt => opt.MapFrom(src => src.QuestionAnswers))
               .ReverseMap();
    }

}

public class CreateUpdateAnswerCommandHandler : IRequestHandler<CreateUpdateAnswerCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CreateUpdateAnswerCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(CreateUpdateAnswerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var Answer = _mapper.Map<DB.Answer>(request);

            if (request.Id > 0)
                _applicationDbContext.Answers.Update(Answer);
            else
                _applicationDbContext.Answers.Add(Answer);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            return await Task.FromResult(false);
        }

    }
}

