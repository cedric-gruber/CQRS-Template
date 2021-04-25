using AutoMapper;

namespace $safeprojectname$.Models.TodoListModels.Mappings
{
    public static class TodoListConfiguration
    {
        public static void AddTodoListProfiles(this IMapperConfigurationExpression config)
        {
            config.AddProfile(typeof(TodoListProfile));
            config.AddProfile(typeof(AllTodosProfile));
            config.AddProfile(typeof(TodosByListProfile));
        }
    }
}
