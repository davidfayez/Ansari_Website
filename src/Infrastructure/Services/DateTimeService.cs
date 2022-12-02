using Ansari_Website.Application.Common.Interfaces;

namespace Ansari_Website.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
