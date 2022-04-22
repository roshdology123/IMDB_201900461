namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        Actor_ID = c.Int(nullable: false, identity: true),
                        FName = c.String(),
                        LName = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Actor_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Actors");
        }
    }
}
