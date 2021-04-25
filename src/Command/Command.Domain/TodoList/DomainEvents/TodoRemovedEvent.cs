using $safeprojectname$.BaseComponents;
using $safeprojectname$.TodoList.ValueObjects;

namespace $safeprojectname$.TodoList.DomainEvents
{
    public class TodoRemovedEvent : IDomainEvent
    {
        public TodoId Id { get; }

        public TodoRemovedEvent(TodoId id)
        {
            Id = id;
        }
    }
}