using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansari_Website.Domain.Entities.CPanel;
public class Survey : AuditableEntity
{
    public int Id { get; set; }
    public int? Rate { get; set; }
    public bool IsViewed { get; set; }
    public string? Feedback { get; set; }
    public virtual IList<SurveyQuestionAnswer> SurveyQuestionAnswers { get; set; }

}
