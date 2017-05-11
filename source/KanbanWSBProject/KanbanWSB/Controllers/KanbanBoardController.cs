using KanbanWSB.Models;
using KanbanWSB.Models.Boards;
using KanbanWSB.Models.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            BoardViewModel model = new BoardViewModel();
            using (var db = new BoardEntityModel())
            {
                var boards = db.Boards.Include(x => x.Columns);
                model.Boards = boards.ToList();

                return View(model);
            }
        }
        public ActionResult CreateBoard()
        {
            return View();
        }
        public ActionResult AddBoard(string name, List<string> columns)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var user = userManager.FindById(User.Identity.GetUserId());
            using (var db = new BoardEntityModel())
            {
                var boardColumns = new List<Column>();
                foreach(var col in columns)
                {
                    boardColumns.Add(new Column() {Name = col });
                }
                var board = new Board() { Name = name, Columns = boardColumns, CreatedDate = DateTime.Now, CreatorEmail =  user.Email};

                db.Boards.Add(board);
                db.SaveChanges();
            }
            
            return null;
        }
    }
}