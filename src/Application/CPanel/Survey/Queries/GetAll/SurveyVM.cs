using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansari_Website.Application.CPanel.Survey.Queries.GetAll;
public class SurveyVM
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public int AnswerId { get; set; }
    public int? Rate { get; set; }
    public string? Feedback { get; set; }
    public string QuestionName { get; set; }
    public string AnswerName { get; set; }
}
