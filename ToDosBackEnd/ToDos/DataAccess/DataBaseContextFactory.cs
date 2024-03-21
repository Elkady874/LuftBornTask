using Microsoft.EntityFrameworkCore;

namespace ToDos.DataAccess
{
    public class DataBaseContextFactory
    {

        private readonly Action<DbContextOptionsBuilder> _configureDbContext;

        public DataBaseContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
        {
            _configureDbContext = configureDbContext;
        }
        public DataBaseContext CreateDataBaseContext()
        {

            DbContextOptionsBuilder<DataBaseContext> optionsBuilder = new();
            _configureDbContext(optionsBuilder);


            return new DataBaseContext(optionsBuilder.Options);

        }
    }
}
