﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansari_Website.Domain.Entities.CPanel;
public class OverViewDetail
{
    public int Id { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public int Value { get; set; }
    public int OverViewId { get; set; }
    public virtual OverView OverView { get; set; }
}
