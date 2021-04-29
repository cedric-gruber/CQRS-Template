using $safeprojectname$.BaseComponents;
using $safeprojectname$.TodoLists.ValueObjects;

namespace $safeprojectname$.TodoLists.DomainEvents
{
    public class TodoCompletedEvent : IDomainEvent
    {
        public TodoId TodoId { get; }

        public TodoCompletedEvent(TodoId todoId)
        {
            TodoId = todoId;
        }
    }
}
