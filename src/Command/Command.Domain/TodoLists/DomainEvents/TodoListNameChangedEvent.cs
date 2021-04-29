using $safeprojectname$.BaseComponents;
using $safeprojectname$.TodoLists.ValueObjects;

namespace $safeprojectname$.TodoLists.DomainEvents
{
    public class TodoListNameChangedEvent : IDomainEvent
    {
        public TodoListName TodoListName { get; }

        public TodoListNameChangedEvent(TodoListName todoListName)
        {
            TodoListName = todoListName;
        }
    }
}
