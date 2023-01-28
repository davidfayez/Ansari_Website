using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansari_Website.Application.Common.Models;
public class LookupSearchDto
{
    public string Keyword { get; set; }
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 50;
    public int Count { get; set; }
    public dynamic Data { get; set; }
}
