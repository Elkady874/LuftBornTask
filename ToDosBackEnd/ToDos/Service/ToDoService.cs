using AutoMapper;
using ToDos.DTOs;
using ToDos.Entities;
using ToDos.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ToDos.Service
{
    public class ToDoService
    {
        private readonly IMapper _mapper;
        private IToDoRepository _toDoRepository;

        public ToDoService(IMapper mapper, IToDoRepository toDoRepository)
        {
            _mapper = mapper;
            _toDoRepository = toDoRepository;
        }
        public async Task<List<ToDo>> GetToDos(){
            List<ToDoItemEntity> todos =await _toDoRepository.GetAllToDosAsync();
          return  _mapper.Map<List<ToDoItemEntity>,List<ToDo>>(todos);

        }
        public async Task<ToDo> GetSingleToDo(int toDoId)
        {
            ToDoItemEntity  todo = await _toDoRepository.GetItemByIdAsync(toDoId);
            return _mapper.Map<ToDoItemEntity, ToDo>(todo);

        }

        public async Task AddToDo(NewTodo item)
        {
           var toDoEntity= _mapper.Map<NewTodo, ToDoItemEntity>(item);
           await _toDoRepository.AddItem(toDoEntity);
             
 
        }

        public async Task DeleteToDo(int itemId)
        {
             await _toDoRepository.DeleteItemAsync(itemId);


        }

        public async Task EditToDo(ToDo item)
        {
            var toDoEntity = _mapper.Map<ToDo, ToDoItemEntity>(item);
            await _toDoRepository.UpdateItemAsync(toDoEntity);


        }
    }
}
