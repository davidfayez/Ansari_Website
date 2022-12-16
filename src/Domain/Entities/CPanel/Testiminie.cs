using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansari_Website.Domain.Entities.CPanel;
public class Testiminie : AuditableEntity
{
    public int Id { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    public string? ImageUrl { get; set; }

    #region Testiminie Details
    public virtual IList<TestiminieDetail> TestiminieDetails { get; set; }

    #endregion

}
