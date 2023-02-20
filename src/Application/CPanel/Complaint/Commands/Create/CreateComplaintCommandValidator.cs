using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Answer.Commands.Create;
using FluentValidation;

namespace Ansari_Website.Application.CPanel.Complaint.Commands.Create;
public class CreateComplaintCommandValidator : AbstractValidator<CreateComplaintCommand>
{
    public CreateComplaintCommandValidator()
    {
        RuleFor(e => e.PhoneNumber).NotNull()
                .WithMessage(ErrorMessages.RequiredMessage.StringFormat(Optic.PhoneNumber));

        RuleFor(e => e.ComplaintMessage).NotNull()
               .WithMessage(ErrorMessages.RequiredMessage.StringFormat(Optic.Complaint));
    }
}