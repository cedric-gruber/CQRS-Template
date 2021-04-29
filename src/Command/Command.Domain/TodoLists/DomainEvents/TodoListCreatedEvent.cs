using $safeprojectname$.BaseComponents;
using $safeprojectname$.TodoLists.ValueObjects;

namespace $safeprojectname$.TodoLists.DomainEvents
{
    public class TodoListCreatedEvent : IDomainEvent
    {
        public TodoListId TodoListId { get; set; }
        public TodoListName TodoListName { get; }

        public TodoListCreatedEvent(TodoListId todoListId, TodoListName todoListName)
        {
            TodoListId = todoListId;
            TodoListName = todoListName;
        }
    }
}
