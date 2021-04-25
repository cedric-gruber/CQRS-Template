using AutoMapper;
using $safeprojectname$.Models.TodoListModels.Mappings;

namespace $safeprojectname$.Models.Mappings
{
    public static class AutoMapperConfiguration
    {
        public static void AddQueryApplicationProfiles(this IMapperConfigurationExpression config)
        {
            config.AddTodoListProfiles();
        }
    }
}
