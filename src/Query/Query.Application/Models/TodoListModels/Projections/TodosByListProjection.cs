using System;

namespace $safeprojectname$.Models.TodoListModels.Projections
{
    public class TodosByListProjection
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
    }
}
