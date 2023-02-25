using Ansari_Website.Application.CPanel.Partner.Queries.GetAll;
using Ansari_Website.Application.CPanel.PatientRight.Queries.GetAll;
using Ansari_Website.Domain.Enums;
using Ansari_Website.Infrastructure.Common;
using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers;
public class PatientRightController : BaseController
{
    public async Task<IActionResult> IndexAsync()
    {
        ViewBag.IsArabic = Request.GetLangIdFromHeader() == (int)ELanguages.AR;
        var PatientRight = await Mediator.Send(new GetAllPatientRightsQuery {LangId = Request.GetLangIdFromHeader() });
        return View(PatientRight);
    }
}
