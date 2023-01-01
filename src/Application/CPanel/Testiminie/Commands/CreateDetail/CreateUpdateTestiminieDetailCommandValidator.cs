using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.Common.Extensions;
using Ansari_Website.Application.Common.Resources;
using Ansari_Website.Application.CPanel.Testiminie.Commands.CreateDetail;
using FluentValidation;

namespace Ansari_Website.Application.CPanel.Testiminie.Commands.CreateDetail;
public class CreateUpdateTestiminieDetailCommandValidator : AbstractValidator<CreateUpdateTestiminieDetailCommand>
{
    public CreateUpdateTestiminieDetailCommandValidator()
    {
        RuleFor(e => e.TitleAr).NotNull()
                .WithMessage(ErrorMessages.RequiredMessage.StringFormat(Global.NameAr));

        RuleFor(e => e.TitleEn).NotNull()
               .WithMessage(ErrorMessages.RequiredMessage.StringFormat(Global.NameEn));

    }
}