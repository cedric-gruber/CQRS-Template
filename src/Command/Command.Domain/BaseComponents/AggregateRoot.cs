using System.Collections.Generic;

namespace $safeprojectname$.BaseComponents
{
    public abstract class AggregateRoot
    {
        private List<IDomainEvent> events = new List<IDomainEvent>();
        public IReadOnlyList<IDomainEvent> Events { get { return events; } }

        protected T AddEvent<T>(T domainEvent) where T : IDomainEvent
        {
            events.Add(domainEvent);
            return domainEvent;
        }

        public abstract void Apply(IDomainEvent domainEvent);
    }
}
