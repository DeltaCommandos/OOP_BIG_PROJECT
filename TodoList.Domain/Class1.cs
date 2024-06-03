using OOP_BIG_PROJECT.Models;
using System.Collections.Generic;
using TodoList.Domain.Entities;
using Microsoft.EntityFrameworkCore; 
using TodoList.Domain.Entities;

namespace TodoList.Domain
{
    public class TodoListContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TaskApp> Tasks { get; set; }
        public TodoListContext(DbContextOptions options) : base(options)
        {

        }
    }
}
