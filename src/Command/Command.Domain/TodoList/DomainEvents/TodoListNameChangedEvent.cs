using $safeprojectname$.BaseComponents;
using $safeprojectname$.TodoList.ValueObjects;

namespace $safeprojectname$.TodoList.DomainEvents
{
    public class TodoListNameChangedEvent : IDomainEvent
    {
        public TodoListName Name { get; }

        public TodoListNameChangedEvent(TodoListName name)
        {
            Name = name;
        }
    }
}
