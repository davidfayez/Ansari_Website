using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansari_Website.Domain.Entities.Identity;
public class AppSetting : AuditableEntity
{
    public int Id { get; set; }
    public string Group { get; set; }
    public string Key { get; set; }
    public int? Type { get; set; }
    public string ValueEn { get; set; }
    public string ValueAr { get; set; }
    public string EndPoint { get; set; }
    public int? ParentId { get; set; }
    public int? SettingType { get; set; }
    public string TitleEn { get; set; }
    public string TitleAr { get; set; }
    public string Image { get; set; }
    public AppSetting Parent { get; set; }
    public ICollection<UserSetting> UserSettings { get; set; }

}
