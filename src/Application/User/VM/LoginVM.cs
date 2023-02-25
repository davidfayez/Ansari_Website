using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ansari_Website.Application.User.VM;
public class LoginVM
{
    [Required(ErrorMessageResourceType = typeof(Application.Common.Resources.ErrorMessages), ErrorMessageResourceName = "Required")]
    [Display(Name = "Email", ResourceType = typeof(Application.Common.Resources.Global))]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessageResourceType = typeof(Application.Common.Resources.ErrorMessages), ErrorMessageResourceName = "Required")]
    [Display(Name = "Password", ResourceType = typeof(Application.Common.Resources.Global))]
    public string Password { get; set; }

    [Display(Name = "RememberMe", ResourceType = typeof(Application.Common.Resources.Global))]
    public bool RememberMe { get; set; }

}
