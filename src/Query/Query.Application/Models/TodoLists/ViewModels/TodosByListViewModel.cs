using System;

namespace $safeprojectname$.Models.TodoLists.ViewModels
{
    public class TodosByListViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public string Content { get; set; }
    }
}
