using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.Common.Extensions;
using Ansari_Website.Application.Common.Resources;
using Ansari_Website.Application.CPanel.Doctor.Commands.Create;
using Ansari_Website.Application.CPanel.Question.Commands.Create;
using FluentValidation;

namespace Ansari_Website.Application.CPanel.Offer.Commands.Create;
public class CreateUpdateOfferCommandValidator : AbstractValidator<CreateUpdateOfferCommand>
{
    public CreateUpdateOfferCommandValidator()
    {
        RuleFor(e => e.TitleAr).NotNull()
                .WithMessage(ErrorMessages.RequiredMessage.StringFormat(Global.NameAr));

        RuleFor(e => e.TitleEn).NotNull()
               .WithMessage(ErrorMessages.RequiredMessage.StringFormat(Global.NameEn));

        RuleFor(e => e.PriceBefore).NotEqual(0)
               .WithMessage(ErrorMessages.RequiredMessage.StringFormat(Optic.PriceBefore));

        RuleFor(e => e.PriceAfter).NotEqual(0)
               .WithMessage(ErrorMessages.RequiredMessage.StringFormat(Optic.PriceAfter));

        //RuleFor(e => e.OfferDetailVMs)
        //        .Must(x=>x!= null && x.Count != 0)
        //        .WithMessage("Please choose at least one detail");

    }
}
