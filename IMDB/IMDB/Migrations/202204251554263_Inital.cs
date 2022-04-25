namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inital : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Likes", "Actor_ID_Actor_ID", "dbo.Actors");
            DropForeignKey("dbo.UserFDirectors", "Actor_ID_Actor_ID", "dbo.Actors");
            DropIndex("dbo.Likes", new[] { "Actor_ID_Actor_ID" });
            DropIndex("dbo.UserFDirectors", new[] { "Actor_ID_Actor_ID" });
            AddColumn("dbo.Likes", "Movie_ID_Movie_ID", c => c.Int());
            AddColumn("dbo.UserFDirectors", "Director_ID_Director_ID", c => c.Int());
            CreateIndex("dbo.Likes", "Movie_ID_Movie_ID");
            CreateIndex("dbo.UserFDirectors", "Director_ID_Director_ID");
            AddForeignKey("dbo.Likes", "Movie_ID_Movie_ID", "dbo.Movies", "Movie_ID");
            AddForeignKey("dbo.UserFDirectors", "Director_ID_Director_ID", "dbo.Directors", "Director_ID");
            DropColumn("dbo.Likes", "Actor_ID_Actor_ID");
            DropColumn("dbo.UserFDirectors", "Actor_ID_Actor_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserFDirectors", "Actor_ID_Actor_ID", c => c.Int());
            AddColumn("dbo.Likes", "Actor_ID_Actor_ID", c => c.Int());
            DropForeignKey("dbo.UserFDirectors", "Director_ID_Director_ID", "dbo.Directors");
            DropForeignKey("dbo.Likes", "Movie_ID_Movie_ID", "dbo.Movies");
            DropIndex("dbo.UserFDirectors", new[] { "Director_ID_Director_ID" });
            DropIndex("dbo.Likes", new[] { "Movie_ID_Movie_ID" });
            DropColumn("dbo.UserFDirectors", "Director_ID_Director_ID");
            DropColumn("dbo.Likes", "Movie_ID_Movie_ID");
            CreateIndex("dbo.UserFDirectors", "Actor_ID_Actor_ID");
            CreateIndex("dbo.Likes", "Actor_ID_Actor_ID");
            AddForeignKey("dbo.UserFDirectors", "Actor_ID_Actor_ID", "dbo.Actors", "Actor_ID");
            AddForeignKey("dbo.Likes", "Actor_ID_Actor_ID", "dbo.Actors", "Actor_ID");
        }
    }
}
