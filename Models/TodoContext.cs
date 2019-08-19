using Microsoft.EntityFrameworkCore;

namespace todo_api.Models
{
    public class TodoContext : DbContext 
    {
        public TodoContext (DbContextOptions<TodoContext> dbOptions): base(dbOptions) 
        {

        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}