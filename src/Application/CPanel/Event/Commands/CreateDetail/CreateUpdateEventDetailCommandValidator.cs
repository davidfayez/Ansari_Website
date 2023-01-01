using FluentValidation;

namespace Ansari_Website.Application.CPanel.Event.Commands.CreateDetail;
public class CreateUpdateEventDetailCommandValidator : AbstractValidator<CreateUpdateEventDetailCommand>
{
    public CreateUpdateEventDetailCommandValidator()
    {
        RuleFor(e => e.TitleAr).NotNull()
                .WithMessage(ErrorMessages.RequiredMessage.StringFormat(Global.NameAr));

        RuleFor(e => e.TitleEn).NotNull()
               .WithMessage(ErrorMessages.RequiredMessage.StringFormat(Global.NameEn));

    }
}
