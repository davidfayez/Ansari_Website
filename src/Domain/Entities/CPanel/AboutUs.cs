using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansari_Website.Domain.Entities.CPanel;
public class AboutUs : AuditableEntity
{
    public int Id { get; set; }
    
    #region Our Mission
    public string? MissionTitleAr { get; set; }
    public string? MissionTitleEn { get; set; }
    public string? MissionIconName { get; set; }
    public string? MissionDescriptionAr { get; set; }
    public string? MissionDescriptionEn { get; set; }
    #endregion

    #region Our Vision
    public string? VisionTitleAr { get; set; }
    public string? VisionTitleEn { get; set; }
    public string? VisionIconName { get; set; }
    public string? VisionDescriptionAr { get; set; }
    public string? VisionDescriptionEn { get; set; }
    #endregion

    #region Our Value
    public virtual IList<OurValue> OurValues { get; set; }

    #endregion

    #region Picture
    public string? ImageUrl { get; set; }

    #endregion
}
