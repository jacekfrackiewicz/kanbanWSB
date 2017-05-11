namespace KanbanWSB.Models.Boards
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BoardEntityModel : DbContext
    {
        public BoardEntityModel()
            : base("name=BoardEntityModel")
        {
        }
        public virtual DbSet<Board> Boards { get; set; }
        public virtual DbSet<Column> Columns { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
