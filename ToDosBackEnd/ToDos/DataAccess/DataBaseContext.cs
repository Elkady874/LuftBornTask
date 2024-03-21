using Microsoft.EntityFrameworkCore;
using ToDos.Entities;

namespace ToDos.DataAccess
{
    public class DataBaseContext: DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ToDoItemEntity> ToDoItems { get; set; }
        
    }
}
