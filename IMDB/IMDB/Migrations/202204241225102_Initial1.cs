namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Img", c => c.Binary());
            DropColumn("dbo.Movies", "Img1");
            DropColumn("dbo.Movies", "Img2");
            DropColumn("dbo.Movies", "Img3");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Img3", c => c.Binary());
            AddColumn("dbo.Movies", "Img2", c => c.Binary());
            AddColumn("dbo.Movies", "Img1", c => c.Binary());
            DropColumn("dbo.Movies", "Img");
        }
    }
}
