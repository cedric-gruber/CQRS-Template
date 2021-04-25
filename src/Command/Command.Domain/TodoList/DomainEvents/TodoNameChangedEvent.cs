using $safeprojectname$.BaseComponents;
using $safeprojectname$.TodoList.ValueObjects;

namespace $safeprojectname$.TodoList.DomainEvents
{
    public class TodoNameChangedEvent : IDomainEvent
    {
        public TodoId Id { get; }
        public TodoName Name { get; }

        public TodoNameChangedEvent(TodoId id, TodoName name)
        {
            Id = id;
            Name = name;
        }
    }
}