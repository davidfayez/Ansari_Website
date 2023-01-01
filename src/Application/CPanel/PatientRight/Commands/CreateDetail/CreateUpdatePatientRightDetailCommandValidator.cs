using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.PatientRight.Commands.CreateDetail;
using FluentValidation;

namespace Ansari_Website.Application.CPanel.PatientRight.Commands.CreateDetail;
public class CreateUpdatePatientRightDetailCommandValidator : AbstractValidator<CreateUpdatePatientRightDetailCommand>
{
    public CreateUpdatePatientRightDetailCommandValidator()
    {
        RuleFor(e => e.TitleAr).NotNull()
                .WithMessage(ErrorMessages.RequiredMessage.StringFormat(Global.NameAr));

        RuleFor(e => e.TitleEn).NotNull()
               .WithMessage(ErrorMessages.RequiredMessage.StringFormat(Global.NameEn));

    }
}
