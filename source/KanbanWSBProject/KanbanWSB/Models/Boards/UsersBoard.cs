namespace KanbanWSB.Models.Boards
{
    public class UsersBoardAccess
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public Permission Permision { get; set; }

    }

    public enum Permission
    {
        Edit,
        Read,
    }
}