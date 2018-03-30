using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
namespace ToDoList.Domain.Entities
{
    public class TaskManager
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int TaskId { get; set; }
        public string Task { get; set; }
        public string Description { get; set; }
        [HiddenInput(DisplayValue = false)]
        public bool Completed { get; set; }
        public DateTime Date { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int PersonId { get; set; }
    }
}