using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using KanbanWSB.Models.Identity;
using Microsoft.AspNet.Identity;

namespace KanbanWSB.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Home()
        {
            return View("Home");
        }

        public void CreateTestUser()
        {
            var userStore = new AppUserStore(new AppDbContext());
            var userManager = new AppUserManager(userStore);
            var user = new AppUser
            {
                UserName = "testKanban",
            };

            var result = userManager.Create(user, "123456");

            if (result.Succeeded)
            {

            }

        }

    }
}