using $safeprojectname$.BaseComponents;
using $safeprojectname$.TodoLists.ValueObjects;

namespace $safeprojectname$.TodoLists.DomainEvents
{
    public class TodoNameChangedEvent : IDomainEvent
    {
        public TodoId TodoId { get; }
        public TodoName TodoName { get; }

        public TodoNameChangedEvent(TodoId todoId, TodoName todoName)
        {
            TodoId = todoId;
            TodoName = todoName;
        }
    }
}