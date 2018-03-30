using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.Domain.Entities;
using System.Data.Entity;

//Associate model with database
namespace ToDoList.Domain
{
    public class EFDbContext : DbContext
    {
        public DbSet<TaskManager> Tasks { get; set; }
    }
}