using System;

namespace $safeprojectname$.Models.TodoLists.Projections
{
    public class TodosByListProjection
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
    }
}
