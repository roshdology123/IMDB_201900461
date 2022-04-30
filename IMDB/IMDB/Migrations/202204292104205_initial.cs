namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
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
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Comment_ID = c.Int(nullable: false, identity: true),
                        CommentData = c.String(),
                        Movie_ID_Movie_ID = c.Int(),
                        User_ID_User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Comment_ID)
                .ForeignKey("dbo.Movies", t => t.Movie_ID_Movie_ID)
                .ForeignKey("dbo.Users", t => t.User_ID_User_ID)
                .Index(t => t.Movie_ID_Movie_ID)
                .Index(t => t.User_ID_User_ID);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Movie_ID = c.Int(nullable: false, identity: true),
                        Movie_Name = c.String(),
                        Director_ID = c.Int(nullable: false),
                        Img = c.Binary(),
                        Movie_TLink = c.String(),
                    })
                .PrimaryKey(t => t.Movie_ID)
                .ForeignKey("dbo.Directors", t => t.Director_ID, cascadeDelete: true)
                .Index(t => t.Director_ID);
            
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        Director_ID = c.Int(nullable: false, identity: true),
                        FName = c.String(),
                        LName = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Director_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        User_ID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        FName = c.String(),
                        LName = c.String(),
                        Role_ID = c.Int(nullable: false),
                        User_Img = c.Binary(),
                    })
                .PrimaryKey(t => t.User_ID);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LikeValue = c.Boolean(nullable: false),
                        Movie_ID_Movie_ID = c.Int(),
                        User_ID_User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Movies", t => t.Movie_ID_Movie_ID)
                .ForeignKey("dbo.Users", t => t.User_ID_User_ID)
                .Index(t => t.Movie_ID_Movie_ID)
                .Index(t => t.User_ID_User_ID);
            
            CreateTable(
                "dbo.MovieActors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Actor_ID_Actor_ID = c.Int(),
                        Movie_ID_Movie_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Actors", t => t.Actor_ID_Actor_ID)
                .ForeignKey("dbo.Movies", t => t.Movie_ID_Movie_ID)
                .Index(t => t.Actor_ID_Actor_ID)
                .Index(t => t.Movie_ID_Movie_ID);
            
            CreateTable(
                "dbo.UserFActors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Actor_ID_Actor_ID = c.Int(),
                        User_ID_User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Actors", t => t.Actor_ID_Actor_ID)
                .ForeignKey("dbo.Users", t => t.User_ID_User_ID)
                .Index(t => t.Actor_ID_Actor_ID)
                .Index(t => t.User_ID_User_ID);
            
            CreateTable(
                "dbo.UserFDirectors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Director_ID_Director_ID = c.Int(),
                        User_ID_User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Directors", t => t.Director_ID_Director_ID)
                .ForeignKey("dbo.Users", t => t.User_ID_User_ID)
                .Index(t => t.Director_ID_Director_ID)
                .Index(t => t.User_ID_User_ID);
            
            CreateTable(
                "dbo.UserFMovies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Movie_ID_Movie_ID = c.Int(),
                        User_ID_User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Movies", t => t.Movie_ID_Movie_ID)
                .ForeignKey("dbo.Users", t => t.User_ID_User_ID)
                .Index(t => t.Movie_ID_Movie_ID)
                .Index(t => t.User_ID_User_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserFMovies", "User_ID_User_ID", "dbo.Users");
            DropForeignKey("dbo.UserFMovies", "Movie_ID_Movie_ID", "dbo.Movies");
            DropForeignKey("dbo.UserFDirectors", "User_ID_User_ID", "dbo.Users");
            DropForeignKey("dbo.UserFDirectors", "Director_ID_Director_ID", "dbo.Directors");
            DropForeignKey("dbo.UserFActors", "User_ID_User_ID", "dbo.Users");
            DropForeignKey("dbo.UserFActors", "Actor_ID_Actor_ID", "dbo.Actors");
            DropForeignKey("dbo.MovieActors", "Movie_ID_Movie_ID", "dbo.Movies");
            DropForeignKey("dbo.MovieActors", "Actor_ID_Actor_ID", "dbo.Actors");
            DropForeignKey("dbo.Likes", "User_ID_User_ID", "dbo.Users");
            DropForeignKey("dbo.Likes", "Movie_ID_Movie_ID", "dbo.Movies");
            DropForeignKey("dbo.Comments", "User_ID_User_ID", "dbo.Users");
            DropForeignKey("dbo.Comments", "Movie_ID_Movie_ID", "dbo.Movies");
            DropForeignKey("dbo.Movies", "Director_ID", "dbo.Directors");
            DropIndex("dbo.UserFMovies", new[] { "User_ID_User_ID" });
            DropIndex("dbo.UserFMovies", new[] { "Movie_ID_Movie_ID" });
            DropIndex("dbo.UserFDirectors", new[] { "User_ID_User_ID" });
            DropIndex("dbo.UserFDirectors", new[] { "Director_ID_Director_ID" });
            DropIndex("dbo.UserFActors", new[] { "User_ID_User_ID" });
            DropIndex("dbo.UserFActors", new[] { "Actor_ID_Actor_ID" });
            DropIndex("dbo.MovieActors", new[] { "Movie_ID_Movie_ID" });
            DropIndex("dbo.MovieActors", new[] { "Actor_ID_Actor_ID" });
            DropIndex("dbo.Likes", new[] { "User_ID_User_ID" });
            DropIndex("dbo.Likes", new[] { "Movie_ID_Movie_ID" });
            DropIndex("dbo.Movies", new[] { "Director_ID" });
            DropIndex("dbo.Comments", new[] { "User_ID_User_ID" });
            DropIndex("dbo.Comments", new[] { "Movie_ID_Movie_ID" });
            DropTable("dbo.UserFMovies");
            DropTable("dbo.UserFDirectors");
            DropTable("dbo.UserFActors");
            DropTable("dbo.MovieActors");
            DropTable("dbo.Likes");
            DropTable("dbo.Users");
            DropTable("dbo.Directors");
            DropTable("dbo.Movies");
            DropTable("dbo.Comments");
            DropTable("dbo.Actors");
        }
    }
}
