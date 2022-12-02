using Ansari_Website.Application.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace Ansari_Website.WebUI.Controllers;
public class BaseController : Controller
{
    private ISender _mediator;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
    protected bool? IsArabicCulture => Request.HttpContext.Features.Get<IRequestCultureFeature>()?.RequestCulture.Culture.Name.Contains("ar");

    protected void UpdateModelState(ValidationException ex)
    {
        ex.Errors.ToList().ForEach(err =>
        {
            err.Value.ToList().ForEach(val =>
            {
                ModelState.AddModelError(err.Key, val);
            });
        });
    }
}
