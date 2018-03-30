using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.Domain;
using ToDoList.Domain.Entities;
namespace ToDoList.Domain
{
    public class EFTaskManagerRepository : ITaskManagerRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<TaskManager> Tasks
        {
            get { return context.Tasks; }
        }

        public TaskManager MarkDone(int taskId)
        {
            TaskManager task = context.Tasks.Find(taskId);
            if(task != null) { 
                task.Completed = true;
            }
            context.SaveChanges();
            return task;
        }

        public void SaveTask(TaskManager myTask)
        {
            context.Tasks.Add(myTask);
            context.SaveChanges();
        }
    }
}