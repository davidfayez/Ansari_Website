using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.Common.Extensions;
using Ansari_Website.Application.Common.Resources;
using Ansari_Website.Application.CPanel.Offer.Commands.Create;
using FluentValidation;

namespace Ansari_Website.Application.CPanel.OverView.Commands.Create;
public class CreateUpdateOverViewCommandValidator : AbstractValidator<CreateUpdateOverViewCommand>
{
    public CreateUpdateOverViewCommandValidator()
    {
        RuleFor(e => e.TitleAr).NotNull()
                .WithMessage(ErrorMessages.RequiredMessage.StringFormat(Global.NameAr));

        RuleFor(e => e.TitleEn).NotNull()
               .WithMessage(ErrorMessages.RequiredMessage.StringFormat(Global.NameEn));


        //RuleFor(e => e.OverViewDetailVMs)
        //        .Must(x=>x!= null && x.Count != 0)
        //        .WithMessage("Please choose at least one detail");

    }
}
