using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Answer.Commands.Create;
using FluentValidation;

namespace Ansari_Website.Application.User.Commands.Create;
public class CreateUpdateVisitorCommandValidator : AbstractValidator<CreateUpdateVisitorCommand>
{
    public CreateUpdateVisitorCommandValidator()
    {
        RuleFor(e => e.PhoneNumber).NotNull()
                .WithMessage(ErrorMessages.RequiredMessage.StringFormat(ErrorMessages.RequiredMessage));

        RuleFor(e => e.FullName).NotNull()
               .WithMessage(ErrorMessages.RequiredMessage.StringFormat(ErrorMessages.RequiredMessage));

        RuleFor(e => e.Password).NotNull()
               .WithMessage(ErrorMessages.RequiredMessage.StringFormat(ErrorMessages.RequiredMessage));


    }
}