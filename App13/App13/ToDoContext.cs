using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App13
{
    public class ToDoContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }

        private string DatabasePath { get; set; }

        public ToDoContext()
        {

        }

        public ToDoContext(string databasePath)
        {
            DatabasePath = databasePath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DatabasePath}");
        }
    }
}
