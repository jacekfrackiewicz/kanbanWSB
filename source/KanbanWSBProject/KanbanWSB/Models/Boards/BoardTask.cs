using System;

namespace KanbanWSB.Models.Boards
{
    public class BoardTask
    {
        public int BoardTaskId { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string CreatorEmail { get; set; }

        public DateTime CreatedDate { get; set; }

        public Column Column { get; set; }
    }
}