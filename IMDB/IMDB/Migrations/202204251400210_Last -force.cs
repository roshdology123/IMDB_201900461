namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Lastforce : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "FName", c => c.String());
            AddColumn("dbo.Users", "LName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "LName");
            DropColumn("dbo.Users", "FName");
        }
    }
}
