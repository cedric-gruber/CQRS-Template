using System;

namespace $safeprojectname$.Models.TodoLists.ViewModels
{
    public class AllTodoListsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int NumberOfTodos { get; set; }
    }
}
