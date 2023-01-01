using FluentValidation;

namespace Ansari_Website.Application.CPanel.Event.Commands.Create;
public class CreateUpdateEventCommandValidator : AbstractValidator<CreateUpdateEventCommand>
{
    public CreateUpdateEventCommandValidator()
    {
        RuleFor(e => e.TitleAr).NotNull()
                .WithMessage(ErrorMessages.RequiredMessage.StringFormat(Global.NameAr));

        RuleFor(e => e.TitleEn).NotNull()
               .WithMessage(ErrorMessages.RequiredMessage.StringFormat(Global.NameEn));


        //RuleFor(e => e.EventDetailVMs)
        //        .Must(x=>x!= null && x.Count != 0)
        //        .WithMessage("Please choose at least one detail");

    }
}

