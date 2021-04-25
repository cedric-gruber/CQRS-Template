using $safeprojectname$.BaseComponents;
using $safeprojectname$.TodoList.ValueObjects;

namespace $safeprojectname$.TodoList.DomainEvents
{
    public class TodoCompletedEvent : IDomainEvent
    {
        public TodoId Id { get; }

        public TodoCompletedEvent(TodoId id)
        {
            Id = id;
        }
    }
}
