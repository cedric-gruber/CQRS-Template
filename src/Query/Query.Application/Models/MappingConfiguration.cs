using AutoMapper;
using $safeprojectname$.Models.TodoLists.Mappings;

namespace $safeprojectname$.Models
{
    public static class MappingConfiguration
    {
        public static void AddQueryApplicationProfiles(this IMapperConfigurationExpression config)
        {
            config.AddTodoListProfiles();
        }
    }
}
