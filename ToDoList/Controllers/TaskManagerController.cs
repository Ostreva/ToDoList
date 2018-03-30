using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Domain.Entities;
using ToDoList.Domain;
using ToDoList.Models;
namespace ToDoList.Controllers
{
    public class TaskManagerController : Controller
    {
        private ITaskManagerRepository repo;
        public int PageSize = 10;
        //Declare dependency for ninject 
        public TaskManagerController(ITaskManagerRepository taskManagerRepo)
        {
            this.repo = taskManagerRepo;
        }

        public ActionResult Completed(int page = 1)
        {
            return RedirectToAction("List", new { category = "Completed" });
        }

        public ActionResult Ongoing(int page = 1)
        {
            return RedirectToAction("List", new { category = "Ongoing" });
        }
        [HttpPost]
        public ActionResult Done(int taskId)
        {
            TaskManager task = repo.MarkDone(taskId);
            if(task != null)
            {
                Console.Write("updated complete");
            }
            return RedirectToAction("List");

        }
        public ViewResult Create()
        {
            TaskManager task = new TaskManager();
            return View(task);
        }
        [HttpPost]
        public ActionResult Create(TaskManager myTask)
        {
            if (ModelState.IsValid)
            {
                myTask.PersonId = 1;
                myTask.Completed = false;
                repo.SaveTask(myTask);
                return RedirectToAction("List");
            }
            return View(myTask);
        }
        public ViewResult List(string category, int page = 1)
        {
            string complete = "Completed";
            string ongoing = "Ongoing";
            TasksListViewModel tl = new TasksListViewModel
            {

                Tasks = repo.Tasks
                .OrderBy(x => x.Date)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PageInfo = new PageInfo
                {
                    CurrentPage = page,
                    TasksPerPage = PageSize,
                    TotalTasks = repo.Tasks.Count()
                },
                CurrentNav = category

            };
            if (category != null && category.Equals(complete))
            {
                tl.Tasks = tl.Tasks.Where(x => x.Completed);
            }
            if (category != null && category.Equals(ongoing))
            {
                tl.Tasks = tl.Tasks.Where(x => !x.Completed);
            }
            return View(tl);
        }
    }
}