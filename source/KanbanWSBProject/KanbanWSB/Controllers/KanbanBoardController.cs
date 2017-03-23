using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KanbanWSB.Controllers
{
    public class KanbanBoardController : Controller
    {
        // GET: KanbanBoard
        public ActionResult Main()
        {
            return View();
        }
    }
}