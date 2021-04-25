using System;

namespace $safeprojectname$.Models.TodoListModels.Projections
{
    public class AllTodoListsProjection
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int NumberOfTodos { get; set; }
    }
}
