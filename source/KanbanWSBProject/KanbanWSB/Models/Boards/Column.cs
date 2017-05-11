using System.Collections;
using System.Collections.Generic;

namespace KanbanWSB.Models.Boards
{
    public class Column
    {
        public int ColumnId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BoardTask> BoardTasks { get; set; }

        public Board Board { get; set; } 
    }
}