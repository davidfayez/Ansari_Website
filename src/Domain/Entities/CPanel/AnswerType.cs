using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansari_Website.Domain.Entities.CPanel;
public class AnswerType : AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual IList<Answer> Answers { get; set; }
    public virtual IList<SurveyQuestion> SurveyQuestions { get; set; }
}
