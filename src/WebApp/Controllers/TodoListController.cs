using $ext_safeprojectname$.Command.Application.Commands.TodoLists;
using $ext_safeprojectname$.Query.Application.Queries.TodoLists;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace $safeprojectname$.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private readonly IMediator mediator;

        public TodoListController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllLists([FromQuery] AllTodoListsQuery query)
            => Ok(await mediator.Send(query));

        [HttpPost("Create")]
        public async Task<IActionResult> CreateList([FromBody] CreateTodoListCommand command)
            => Ok(await mediator.Send(command));

        [HttpPost("ChangeName")]
        public async Task<IActionResult> ChangeListName([FromBody] ChangeTodoListNameCommand command)
            => Ok(await mediator.Send(command));

        [HttpGet("Todo")]
        public async Task<IActionResult> GetAllTodos([FromQuery] AllTodosQuery query)
            => Ok(await mediator.Send(query));

        [HttpGet("{TodoListId}/Todo")]
        public async Task<IActionResult> GetTodosByList([FromRoute] TodosByListQuery query)
            => Ok(await mediator.Send(query));

        [HttpPost("Todo/Create")]
        public async Task<IActionResult> CreateTodo([FromBody] CreateTodoCommand command)
            => Ok(await mediator.Send(command));

        [HttpPost("Todo/Complete")]
        public async Task<IActionResult> CompleteTodo([FromBody] CompleteTodoCommand command)
            => Ok(await mediator.Send(command));

        [HttpPost("Todo/Remove")]
        public async Task<IActionResult> RemoveTodo([FromBody] RemoveTodoCommand command)
            => Ok(await mediator.Send(command));

        [HttpPost("Todo/ChangeName")]
        public async Task<IActionResult> ChangeTodoName([FromBody] ChangeTodoNameCommand command)
            => Ok(await mediator.Send(command));
    }
}
