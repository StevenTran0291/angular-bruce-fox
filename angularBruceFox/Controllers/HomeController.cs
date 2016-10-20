using angularBruceFox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace angularBruceFox.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            using (var ctx = new TaskRecordContext())
            {
                TaskRecord lol = new TaskRecord() { Quote_Type = "LOL", Quote_Number = 1, Contact = "LOL", Task_Record = "LOL", Due_Date = System.DateTime.Now, Task_Type = "LOL" };

                ctx.Taskss.Add(lol);
                ctx.SaveChanges();
            }

            return View();
        }
    }
}
