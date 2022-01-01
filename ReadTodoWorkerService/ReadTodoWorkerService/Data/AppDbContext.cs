using Microsoft.EntityFrameworkCore;
using ReadTodoWorkerService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadTodoWorkerService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public virtual DbSet<BoardTask> BoardTasks { get; set; }
    }
}
