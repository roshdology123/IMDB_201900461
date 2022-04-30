namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modelization : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Director_ID", "dbo.Directors");
            DropIndex("dbo.Movies", new[] { "Director_ID" });
            RenameColumn(table: "dbo.Comments", name: "Movie_ID_Movie_ID", newName: "Movie_ID");
            RenameColumn(table: "dbo.Comments", name: "User_ID_User_ID", newName: "User_ID");
            RenameColumn(table: "dbo.Likes", name: "Movie_ID_Movie_ID", newName: "Movie_ID");
            RenameColumn(table: "dbo.Likes", name: "User_ID_User_ID", newName: "User_ID");
            RenameColumn(table: "dbo.MovieActors", name: "Actor_ID_Actor_ID", newName: "Actor_ID");
            RenameColumn(table: "dbo.MovieActors", name: "Movie_ID_Movie_ID", newName: "Movie_ID");
            RenameColumn(table: "dbo.UserFActors", name: "Actor_ID_Actor_ID", newName: "Actor_ID");
            RenameColumn(table: "dbo.UserFActors", name: "User_ID_User_ID", newName: "User_ID");
            RenameColumn(table: "dbo.UserFDirectors", name: "Director_ID_Director_ID", newName: "Director_ID");
            RenameColumn(table: "dbo.UserFDirectors", name: "User_ID_User_ID", newName: "User_ID");
            RenameColumn(table: "dbo.UserFMovies", name: "Movie_ID_Movie_ID", newName: "Movie_ID");
            RenameIndex(table: "dbo.Comments", name: "IX_User_ID_User_ID", newName: "IX_User_ID");
            RenameIndex(table: "dbo.Comments", name: "IX_Movie_ID_Movie_ID", newName: "IX_Movie_ID");
            RenameIndex(table: "dbo.Likes", name: "IX_User_ID_User_ID", newName: "IX_User_ID");
            RenameIndex(table: "dbo.Likes", name: "IX_Movie_ID_Movie_ID", newName: "IX_Movie_ID");
            RenameIndex(table: "dbo.MovieActors", name: "IX_Movie_ID_Movie_ID", newName: "IX_Movie_ID");
            RenameIndex(table: "dbo.MovieActors", name: "IX_Actor_ID_Actor_ID", newName: "IX_Actor_ID");
            RenameIndex(table: "dbo.UserFActors", name: "IX_User_ID_User_ID", newName: "IX_User_ID");
            RenameIndex(table: "dbo.UserFActors", name: "IX_Actor_ID_Actor_ID", newName: "IX_Actor_ID");
            RenameIndex(table: "dbo.UserFDirectors", name: "IX_User_ID_User_ID", newName: "IX_User_ID");
            RenameIndex(table: "dbo.UserFDirectors", name: "IX_Director_ID_Director_ID", newName: "IX_Director_ID");
            RenameIndex(table: "dbo.UserFMovies", name: "IX_Movie_ID_Movie_ID", newName: "IX_Movie_ID");
            AlterColumn("dbo.Movies", "Director_ID", c => c.Int());
            CreateIndex("dbo.Movies", "Director_ID");
            AddForeignKey("dbo.Movies", "Director_ID", "dbo.Directors", "Director_ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Director_ID", "dbo.Directors");
            DropIndex("dbo.Movies", new[] { "Director_ID" });
            AlterColumn("dbo.Movies", "Director_ID", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.UserFMovies", name: "IX_Movie_ID", newName: "IX_Movie_ID_Movie_ID");
            RenameIndex(table: "dbo.UserFDirectors", name: "IX_Director_ID", newName: "IX_Director_ID_Director_ID");
            RenameIndex(table: "dbo.UserFDirectors", name: "IX_User_ID", newName: "IX_User_ID_User_ID");
            RenameIndex(table: "dbo.UserFActors", name: "IX_Actor_ID", newName: "IX_Actor_ID_Actor_ID");
            RenameIndex(table: "dbo.UserFActors", name: "IX_User_ID", newName: "IX_User_ID_User_ID");
            RenameIndex(table: "dbo.MovieActors", name: "IX_Actor_ID", newName: "IX_Actor_ID_Actor_ID");
            RenameIndex(table: "dbo.MovieActors", name: "IX_Movie_ID", newName: "IX_Movie_ID_Movie_ID");
            RenameIndex(table: "dbo.Likes", name: "IX_Movie_ID", newName: "IX_Movie_ID_Movie_ID");
            RenameIndex(table: "dbo.Likes", name: "IX_User_ID", newName: "IX_User_ID_User_ID");
            RenameIndex(table: "dbo.Comments", name: "IX_Movie_ID", newName: "IX_Movie_ID_Movie_ID");
            RenameIndex(table: "dbo.Comments", name: "IX_User_ID", newName: "IX_User_ID_User_ID");
            RenameColumn(table: "dbo.UserFMovies", name: "Movie_ID", newName: "Movie_ID_Movie_ID");
            RenameColumn(table: "dbo.UserFDirectors", name: "User_ID", newName: "User_ID_User_ID");
            RenameColumn(table: "dbo.UserFDirectors", name: "Director_ID", newName: "Director_ID_Director_ID");
            RenameColumn(table: "dbo.UserFActors", name: "User_ID", newName: "User_ID_User_ID");
            RenameColumn(table: "dbo.UserFActors", name: "Actor_ID", newName: "Actor_ID_Actor_ID");
            RenameColumn(table: "dbo.MovieActors", name: "Movie_ID", newName: "Movie_ID_Movie_ID");
            RenameColumn(table: "dbo.MovieActors", name: "Actor_ID", newName: "Actor_ID_Actor_ID");
            RenameColumn(table: "dbo.Likes", name: "User_ID", newName: "User_ID_User_ID");
            RenameColumn(table: "dbo.Likes", name: "Movie_ID", newName: "Movie_ID_Movie_ID");
            RenameColumn(table: "dbo.Comments", name: "User_ID", newName: "User_ID_User_ID");
            RenameColumn(table: "dbo.Comments", name: "Movie_ID", newName: "Movie_ID_Movie_ID");
            CreateIndex("dbo.Movies", "Director_ID");
            AddForeignKey("dbo.Movies", "Director_ID", "dbo.Directors", "Director_ID", cascadeDelete: true);
        }
    }
}
