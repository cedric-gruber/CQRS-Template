using $safeprojectname$.BaseComponents;
using $safeprojectname$.TodoList.ValueObjects;

namespace $safeprojectname$.TodoList.DomainEvents
{
    public class TodoAddedEvent : IDomainEvent
    {
        public TodoId Id { get; }
        public TodoName Name { get; }

        public TodoAddedEvent(TodoId id, TodoName name)
        {
            Id = id;
            Name = name;
        }
    }
}
