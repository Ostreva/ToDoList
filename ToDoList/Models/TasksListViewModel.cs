using System.Collections.Generic;
using ToDoList.Domain.Entities;

namespace ToDoList.Models
{
    //View Model for page info and TaskManager instance
    public class TasksListViewModel
    {
        public IEnumerable<TaskManager> Tasks { get; set; }
        public PageInfo PageInfo { get; set; }
        public string CurrentNav { get; set; }
    }
}