using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
    //Information for current page, number of pages, and total tasks
    public class PageInfo
    {
        
        public int TotalTasks { get; set; }
        public int TasksPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages { get {
                return (int)Math.Ceiling((decimal)TotalTasks / TasksPerPage);
            }
        }
    }
}