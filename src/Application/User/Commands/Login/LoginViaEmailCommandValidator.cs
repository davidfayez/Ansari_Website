using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.User.Commands.Create;
using FluentValidation;

namespace Ansari_Website.Application.User.Commands.Login;
public class LoginViaEmailCommandValidator : AbstractValidator<LoginViaEmailCommand>
{
    public LoginViaEmailCommandValidator()
    {
        RuleFor(e => e.Email).NotNull()
                .WithMessage(ErrorMessages.RequiredMessage.StringFormat(ErrorMessages.RequiredMessage))
                .EmailAddress()
                .WithMessage(ErrorMessages.EmailNotValid);

        //RuleFor(e => e.FullName).NotNull()
        //       .WithMessage(ErrorMessages.RequiredMessage.StringFormat(ErrorMessages.RequiredMessage));

        RuleFor(e => e.Password).NotNull()
               .WithMessage(ErrorMessages.RequiredMessage.StringFormat(ErrorMessages.RequiredMessage));


    }
}