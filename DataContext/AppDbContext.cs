using Microsoft.EntityFrameworkCore;
using ToDo.Models;

namespace ToDo.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Todo> todos { get; set; }
    }
}
