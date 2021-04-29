using System;

namespace $safeprojectname$.Models.TodoLists.Projections
{
    public class AllTodoListsProjection
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int NumberOfTodos { get; set; }
    }
}
