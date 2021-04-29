using $safeprojectname$.BaseComponents;
using $safeprojectname$.TodoLists.ValueObjects;

namespace $safeprojectname$.TodoLists.DomainEvents
{
    public class TodoAddedEvent : IDomainEvent
    {
        public TodoId TodoId { get; }
        public TodoName TodoName { get; }

        public TodoAddedEvent(TodoId todoId, TodoName todoName)
        {
            TodoId = todoId;
            TodoName = todoName;
        }
    }
}
