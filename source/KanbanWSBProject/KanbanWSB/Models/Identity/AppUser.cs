using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KanbanWSB.Models.Identity
{
    public class AppUser : IdentityUser
    {
        public AppUser() : base()
        {

        }
            
    }
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext() : base("KanbanWsbConnString")
        {

        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
    }
}