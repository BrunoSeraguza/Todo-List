
using Microsoft.EntityFrameworkCore;
using todoList.Models;

namespace todoList.Data
{
    public class AppDbContext : DbContext
    {   //representação da tabela no BD
        public DbSet<TodoModel> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
    }
}