using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Question.Commands.Create;
using Ansari_Website.Domain.Entities.CPanel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ansari_Website.Application.CPanel.Question.Commands.Create;
public class CreateUpdateQuestionCommand : AuditableEntity, IRequest<bool>, IMapFrom<DB.Question>
{
    public int Id { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public int? Order { get; set; }
    public List<int> AnswersId { get; set; }
    public List<SelectListItem> Answers { get; set; } = new();

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DB.Question, CreateUpdateQuestionCommand>()
                .ForMember(des => des.AnswersId, opt => opt.MapFrom(src => src.QuestionAnswers.Select(s=>s.AnswerId)))
               .ReverseMap();
    }

}

public class CreateUpdateQuestionCommandHandler : IRequestHandler<CreateUpdateQuestionCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CreateUpdateQuestionCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(CreateUpdateQuestionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var Question = _mapper.Map<DB.Question>(request);
            var QuestionAnswers = new List<QuestionAnswer>();
            
            if (request.Id > 0)
            {
                var ExistsId = _applicationDbContext.QuestionAnswers
                                                    .Where(s => s.QuestionId == request.Id)
                                                    .Select(s => s.AnswerId).ToList();

                var RemovedAnswers = ExistsId.Except(request.AnswersId);
                var InsertedAnswers = request.AnswersId.Except(ExistsId).ToList();
                    
                foreach (var answerId in RemovedAnswers)
                {
                    var RemovedQuestionAnswer = _applicationDbContext.QuestionAnswers
                                                 .FirstOrDefault(s => s.QuestionId == request.Id && s.AnswerId == answerId);
                    
                    if(RemovedQuestionAnswer != null)
                        _applicationDbContext.QuestionAnswers.Remove(RemovedQuestionAnswer);

                }
                InsertedAnswers.ForEach(s => QuestionAnswers.Add(new QuestionAnswer { AnswerId = s }));
                Question.QuestionAnswers = QuestionAnswers;
                _applicationDbContext.Questions.Update(Question);

            }
            else
            {
                request.AnswersId.ForEach(s => QuestionAnswers.Add(new QuestionAnswer { AnswerId = s }));
                Question.QuestionAnswers = QuestionAnswers;
                _applicationDbContext.Questions.Add(Question);

            }

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            return await Task.FromResult(false);
        }

    }
}

