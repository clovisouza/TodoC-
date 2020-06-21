using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contract;
using Todo.Domain.Entities;
using Todo.Domain.Handler;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    [Authorize]
    public class TodoController : ControllerBase
    {

        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll([FromServices] ITodoRepository repository)
        {
            
            return repository.GetAll(UserAuthentication());
        }

        [Route("AllDone")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDone([FromServices] ITodoRepository repository)
        {
            
            return repository.GetAllDone(UserAuthentication());
        }

        [Route("UnDone")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllUnDone([FromServices] ITodoRepository repository)
        {

            return repository.GetAllUnDone(UserAuthentication());
        }

        [Route("done/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForToday([FromServices] ITodoRepository repository)
        {
            
            return repository.GetByPeriod(UserAuthentication(),DateTime.Today, true);
        }

        [Route("undone/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUnDoneForToday([FromServices] ITodoRepository repository)
        {

            return repository.GetByPeriod(UserAuthentication(), DateTime.Today, false);
        }

        [Route("done/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForTomorrow([FromServices] ITodoRepository repository)
        {
            
            return repository.GetByPeriod(UserAuthentication(), DateTime.Now.AddDays(1), true);
        }

        [Route("undone/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUnDoneForTomorrow([FromServices] ITodoRepository repository)
        {
            
            return repository.GetByPeriod(UserAuthentication(), DateTime.Now.AddDays(1), false);
        }

        [Route("")]        
        [HttpPost]
        public GenericCommandResult Create([FromBody] CreateTodoCommand command,[FromServices] TodoHandler handler)
        {
            command.User = UserAuthentication();
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult Update([FromBody] UpdateTodoCommand command, [FromServices] TodoHandler handler)
        {
            command.User = UserAuthentication();
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("mark-as-done")]
        [HttpPut]
        public GenericCommandResult MarkAsDone([FromBody] MarkTodoAsDoneCommand command, [FromServices] TodoHandler handler)
        {
            command.User = UserAuthentication();
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("mark-as-Undone")]
        [HttpPut]
        public GenericCommandResult MarkAsUnDone([FromBody] MarkTodoAsUndoneCommand command, [FromServices] TodoHandler handler)
        {
            command.User = UserAuthentication();
            return (GenericCommandResult)handler.Handle(command);
        }

        private string UserAuthentication()
        {
            return User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        }

    }
}