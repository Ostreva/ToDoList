using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.Domain.Entities;
namespace ToDoList.Domain
{
    public interface ITaskManagerRepository
    {
        //Obtain a Manage object 
        //without needing to know where data is stored
        IEnumerable<TaskManager> Tasks { get; }

        TaskManager MarkDone(int taskId);

        void SaveTask(TaskManager task);
    }
}