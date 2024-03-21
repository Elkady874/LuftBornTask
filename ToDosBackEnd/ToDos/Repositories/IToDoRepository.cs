using ToDos.Entities;

namespace ToDos.Repositories
{
    public interface IToDoRepository
    {
        Task AddItem(ToDoItemEntity item);
        Task UpdateItemAsync(ToDoItemEntity todoItem);
        Task DeleteItemAsync(int itemId);
        Task<ToDoItemEntity> GetItemByIdAsync(int itemId);
        Task<List<ToDoItemEntity>> GetAllToDosAsync();
    }
}
