using KanbanWSB.Models.Identity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace KanbanWSB.Models.Boards
{
    public class Board
    {
        public int BoardId { get; set; }
        public string Name { get; set; }
        public string CreatorEmail { get; set; }

        public virtual ICollection<UsersBoardAccess> UsersBoardAccesses { get;set;}

        public DateTime CreatedDate { get; set; }

        public  virtual ICollection<Column> Columns { get; set; }

    }
}