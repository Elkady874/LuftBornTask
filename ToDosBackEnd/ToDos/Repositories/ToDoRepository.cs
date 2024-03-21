using Microsoft.EntityFrameworkCore;
using ToDos.DataAccess;
using ToDos.Entities;

namespace ToDos.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly DataBaseContextFactory _context;
        public ToDoRepository(DataBaseContextFactory context)
        {
            _context = context;
        }
        public async Task AddItem(ToDoItemEntity item)
        {
            using DataBaseContext dataBaseContext = _context.CreateDataBaseContext();
            dataBaseContext.ToDoItems.Add(item);
            _ = await dataBaseContext.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(int itemId)
        {

            using DataBaseContext dataBaseContext = _context.CreateDataBaseContext();
            var Item = await GetItemByIdAsync(itemId);
            if (Item == null) { return; }
            dataBaseContext.Remove(Item);
            _ = await dataBaseContext.SaveChangesAsync();
        }

        public async Task UpdateItemAsync(ToDoItemEntity todoItem)
        {
            using DataBaseContext dataBaseContext = _context.CreateDataBaseContext();
            var _Item = await dataBaseContext.ToDoItems
            .FirstOrDefaultAsync(item => item.Id == todoItem.Id);
            if (_Item != null)
            {
                _Item.Done = todoItem.Done;
                _Item.Description = todoItem.Description;
            }
            _ = await dataBaseContext.SaveChangesAsync();
        }

        public async Task<ToDoItemEntity> GetItemByIdAsync(int itemId)
        {
            using DataBaseContext dataBaseContext = _context.CreateDataBaseContext();
            return await dataBaseContext.ToDoItems.AsNoTracking()
                 .FirstOrDefaultAsync(item => item.Id == itemId);
        }

        public async Task<List<ToDoItemEntity>> GetAllToDosAsync()
        {
            using DataBaseContext dataBaseContext = _context.CreateDataBaseContext();
            return await dataBaseContext.ToDoItems.AsNoTracking().Select(e=>e).ToListAsync();
              
        }
    }
}
