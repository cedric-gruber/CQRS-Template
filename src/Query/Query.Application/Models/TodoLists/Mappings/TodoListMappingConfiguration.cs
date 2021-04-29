using AutoMapper;
using $safeprojectname$.Models.TodoLists.Mappings.Profiles;

namespace $safeprojectname$.Models.TodoLists.Mappings
{
    public static class TodoListMappingConfiguration
    {
        public static void AddTodoListProfiles(this IMapperConfigurationExpression config)
        {
            config.AddProfile(typeof(TodoListProfile));
            config.AddProfile(typeof(AllTodosProfile));
            config.AddProfile(typeof(TodosByListProfile));
        }
    }
}
