

using Microsoft.AspNetCore.Mvc;
using ToDos.Core;
using ToDos.DTOs;
using ToDos.Service;

namespace ToDos.Controllers
{
    [Route("api/[controller]")]
    [ExceptionHandler]
    public class ToDoController : ControllerBase
    {
        private ToDoService _toDoService;
        public ToDoController(ToDoService toDoService)
        {
            _toDoService = toDoService;    
        }
        [HttpGet]
        [Route(nameof(GetToDoItems))]
        public async Task<IActionResult> GetToDoItems()
        {
            var items = await _toDoService.GetToDos();
            if (items == null || !items.Any()) { return NoContent(); }
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetToDoItemById(int id)
        {
            var item = await _toDoService.GetSingleToDo(id);
            if (item == null ) { return NoContent(); }
            return Ok(item);
        }
        [HttpPost]
        [Route(nameof(AddToDoItems))]
        public async Task<IActionResult> AddToDoItems([FromBody]  NewTodo item)
        {
            await _toDoService.AddToDo(item);
            return Ok("SuccessFull Insert");
        }
        [HttpDelete]
        [Route(nameof(RemoveToDo))]
        public async Task<IActionResult> RemoveToDo(int itemId)
        {
            await _toDoService.DeleteToDo(itemId);
            return Ok("SuccessFull Delete");
        }
        [HttpPut]
        [Route(nameof(EditToDo))]
        public async Task<IActionResult> EditToDo(ToDo item)
        {
            await _toDoService.EditToDo(item);
            return Ok("SuccessFull Update");
        }

    }
}
