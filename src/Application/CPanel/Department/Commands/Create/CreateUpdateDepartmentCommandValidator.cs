using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Event.Commands.Create;
using FluentValidation;

namespace Ansari_Website.Application.CPanel.Department.Commands.Create;
public class CreateUpdateDepartmentCommandValidator : AbstractValidator<CreateUpdateDepartmentCommand>
{
    public CreateUpdateDepartmentCommandValidator()
    {
        RuleFor(e => e.TitleAr).NotNull()
                .WithMessage(ErrorMessages.RequiredMessage.StringFormat(Global.NameAr));

        RuleFor(e => e.TitleEn).NotNull()
               .WithMessage(ErrorMessages.RequiredMessage.StringFormat(Global.NameEn));

        RuleFor(e => e.Speciality).NotNull()
               .WithMessage(ErrorMessages.RequiredMessage.StringFormat(Global.NameEn));

        //RuleFor(e => e.EventDetailVMs)
        //        .Must(x=>x!= null && x.Count != 0)
        //        .WithMessage("Please choose at least one detail");

    }
}
