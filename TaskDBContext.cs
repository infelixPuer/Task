using CRUDTask.Models;
using System.Data.Entity;

namespace CRUDTask
{
    public class TaskDBContext : DbContext
    {
        public TaskDBContext() : base("TaskDBContext")
        {  
        }

        public DbSet<User> Users { get; set; }
    }
}