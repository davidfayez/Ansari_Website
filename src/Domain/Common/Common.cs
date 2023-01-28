﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansari_Website.Domain.Common;
public class Common
{
    public int Id { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public int CreatedBy { get; set; }
    public DateTime? ModefiedOn { get; set; }
    public int? ModefiedBy { get; set; }
    public DateTime? DeletedOn { get; set; }
    public int? DeletedBy { get; set; }
    public bool IsActive { get; set; } = true;
}
