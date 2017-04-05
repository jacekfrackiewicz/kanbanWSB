using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KanbanWSB.Controllers
{
    [Authorize]
    public class KanbanBoardController : Controller
    {
        public ActionResult Main()
        {
            return View();
        }
        public ActionResult CreateBoard()
        {
            return View();
        }
    }
}