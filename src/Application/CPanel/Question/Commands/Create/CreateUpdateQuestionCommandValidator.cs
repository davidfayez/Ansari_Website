using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.Common.Extensions;
using Ansari_Website.Application.Common.Resources;
using FluentValidation;

namespace Ansari_Website.Application.CPanel.Question.Commands.Create;
public class CreateUpdateQuestionCommandValidator : AbstractValidator<CreateUpdateQuestionCommand>
{
    public CreateUpdateQuestionCommandValidator()
    {
        RuleFor(e => e.TitleAr).NotNull()
                .WithMessage(ErrorMessages.RequiredMessage.StringFormat(Global.NameAr));

        RuleFor(e => e.TitleEn).NotNull()
               .WithMessage(ErrorMessages.RequiredMessage.StringFormat(Global.NameEn));

        RuleFor(e => e.AnswersId).NotNull()
                .WithMessage("Please choose at least one Answer");

    }
}