namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondary : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Director_ID_Director_ID", "dbo.Directors");
            DropIndex("dbo.Movies", new[] { "Director_ID_Director_ID" });
            RenameColumn(table: "dbo.Movies", name: "Director_ID_Director_ID", newName: "Director_ID");
            AlterColumn("dbo.Movies", "Director_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "Director_ID");
            AddForeignKey("dbo.Movies", "Director_ID", "dbo.Directors", "Director_ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Director_ID", "dbo.Directors");
            DropIndex("dbo.Movies", new[] { "Director_ID" });
            AlterColumn("dbo.Movies", "Director_ID", c => c.Int());
            RenameColumn(table: "dbo.Movies", name: "Director_ID", newName: "Director_ID_Director_ID");
            CreateIndex("dbo.Movies", "Director_ID_Director_ID");
            AddForeignKey("dbo.Movies", "Director_ID_Director_ID", "dbo.Directors", "Director_ID");
        }
    }
}
