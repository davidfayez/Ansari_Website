﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansari_Website.Domain.Entities.CPanel;
public class Question : AuditableEntity
{
    public int Id { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public int? Order { get; set; }
    public virtual IList<QuestionAnswer> QuestionAnswers { get; set; }

}
