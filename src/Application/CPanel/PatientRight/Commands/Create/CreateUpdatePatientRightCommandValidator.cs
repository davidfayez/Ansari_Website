using FluentValidation;

namespace Ansari_Website.Application.CPanel.PatientRight.Commands.Create;
public class CreateUpdatePatientRightCommandValidator : AbstractValidator<CreateUpdatePatientRightCommand>
{
    public CreateUpdatePatientRightCommandValidator()
    {
        RuleFor(e => e.TitleAr).NotNull()
                .WithMessage(ErrorMessages.RequiredMessage.StringFormat(Global.NameAr));

        RuleFor(e => e.TitleEn).NotNull()
               .WithMessage(ErrorMessages.RequiredMessage.StringFormat(Global.NameEn));


        //RuleFor(e => e.PatientRightDetailVMs)
        //        .Must(x=>x!= null && x.Count != 0)
        //        .WithMessage("Please choose at least one detail");

    }
}

