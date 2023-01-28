using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Ansari_Website.Application.Common.Models;
public class AppSettingDto : AuditableEntity
{
    public int Id { get; set; }

    [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessages))]
    public string Group { get; set; }

    [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessages))]
    public string Key { get; set; }


    [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessages))]
    public int Type { get; set; }
    [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessages))]
    public string ValueEn { get; set; }
    [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessages))]
    public string ValueAr { get; set; }
    public int? SettingType { get; set; }
    public string Value { get; set; }
    public string EndPoint { get; set; }
    public int? ParentId { get; set; }
    public string ParentSetting { get; set; }
    public string TitleEn { get; set; }
    public string TitleAr { get; set; }
    public string Image { get; set; }
}

public class AddAppSettingDto
{
    [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessages))]
    public string Group { get; set; }
    [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessages))]
    public string Key { get; set; }
    [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessages))]
    public int Type { get; set; }
    [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessages))]
    public string ValueEn { get; set; }
    [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessages))]
    public string ValueAr { get; set; }

    public int? SettingType { get; set; }
    public string Value { get; set; }
    public string EndPoint { get; set; }
    public int? ParentId { get; set; }
    public string ParentSetting { get; set; }
    public string TitleEn { get; set; }
    public string TitleAr { get; set; }
    public string Image { get; set; }
    public IFormFile ImageFile { get; set; }
}

public class UpdateAppSettingDto : AddAppSettingDto
{
    public int Id { get; set; }
}
