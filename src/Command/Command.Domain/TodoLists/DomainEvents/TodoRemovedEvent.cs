using $safeprojectname$.BaseComponents;
using $safeprojectname$.TodoLists.ValueObjects;

namespace $safeprojectname$.TodoLists.DomainEvents
{
    public class TodoRemovedEvent : IDomainEvent
    {
        public TodoId TodoId { get; }

        public TodoRemovedEvent(TodoId todoId)
        {
            TodoId = todoId;
        }
    }
}