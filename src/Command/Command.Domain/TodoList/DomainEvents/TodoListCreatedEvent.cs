using $safeprojectname$.BaseComponents;
using $safeprojectname$.TodoList.ValueObjects;

namespace $safeprojectname$.TodoList.DomainEvents
{
    public class TodoListCreatedEvent : IDomainEvent
    {
        public TodoListId Id { get; set; }
        public TodoListName Name { get; }

        public TodoListCreatedEvent(TodoListId id, TodoListName name)
        {
            Id = id;
            Name = name;
        }
    }
}
