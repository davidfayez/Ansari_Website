using Ansari_Website.Domain.Common;

namespace Ansari_Website.Application.Common.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}
