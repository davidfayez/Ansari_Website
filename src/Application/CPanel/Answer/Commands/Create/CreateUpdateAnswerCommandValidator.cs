using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.Common.Extensions;
using Ansari_Website.Application.Common.Resources;
using Ansari_Website.Application.CPanel.Question.Commands.Create;
using FluentValidation;

namespace Ansari_Website.Application.CPanel.Answer.Commands.Create;
public class CreateUpdateAnswerCommandValidator : AbstractValidator<CreateUpdateAnswerCommand>
{
    public CreateUpdateAnswerCommandValidator()
    {
        RuleFor(e => e.NameAr).NotNull()
                .WithMessage(ErrorMessages.RequiredMessage.StringFormat(Global.NameAr));

        RuleFor(e => e.NameEn).NotNull()
               .WithMessage(ErrorMessages.RequiredMessage.StringFormat(Global.NameEn));


    }
}