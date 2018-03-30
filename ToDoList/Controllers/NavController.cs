using System.Collections.Generic;
using ToDoList.Domain;
using System.Linq;
using System.Web.Mvc;

namespace ToDoList.Controllers
{
    public class NavController : Controller
    {

        public PartialViewResult Menu()
        {
            IEnumerable<string> category = new List<string>() {
                                    "Completed", "All", "Add", "Edit", "Remove" };
            return PartialView(category);
        }
    }
}