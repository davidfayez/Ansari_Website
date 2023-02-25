using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansari_Website.Domain.Entities.CPanel;
public class SurveyQuestionAnswer
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public int AnswerId { get; set; }
    public int SurveyId { get; set; }
    public virtual Survey Survey { get; set; }
    public virtual Question Question { get; set; }
    public virtual Answer Answer { get; set; }
}
