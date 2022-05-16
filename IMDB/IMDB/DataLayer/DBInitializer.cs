using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using IMDB.Models;
using System.Drawing;
using IMDB.Controllers;
using System.IO;

namespace IMDB.DataLayer
{
    public class DBInitializer 
    {
        public static void Seed() 
        {
            using(IMdbDBContext context = new IMdbDBContext()) { 
            context.Database.CreateIfNotExists();

            if (!context.Actors.Any())
            {
                context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            Age = 21,
                            FName = "Abdallah",
                            LName = "Roshdy"
                        },
                        new Actor()
                        {
                            Age = 22,
                            FName = "Omar",
                            LName = "Hassan"
                        },
                        new Actor()
                        {
                            Age = 20,
                            FName = "Bedo",
                            LName = "Faisal"
                        },

                    });
                context.SaveChanges();
            }

            if (!context.Directors.Any())
            {
                context.Directors.AddRange(new List<Director>()
                {
                    new Director()
                    {
                        Age = 21,
                        FName = "Abdallah",
                        LName = "Roshdy"
                    },
                    new Director()
                    {
                        Age = 22,
                        FName = "Omar",
                        LName = "Hassan"
                    },
                    new Director()
                    {
                        Age = 20,
                        FName = "Bedo",
                        LName = "Faisal"
                    },

                });
                context.SaveChanges();
            }


                if (context.Users.Any())
            {
                    Image fileImage = Image.FromFile("C:/Users/roshd/Git-Hub/IMDB_201900461/IMDB/IMDB/Content/Images/47857.jpg");

                    byte[] ImageData = ImageConversion.ImageToByteArray(fileImage);


                context.Users.AddRange(new List<User>()
                {
                    new User()
                    {
                        FName = "Abdallah",
                        LName = "Roshdy",
                        Email = "abdallahelswify@gmail.com",
                        Password = "@Bdallah123",
                        User_Img = ImageData
                    },
                    new User()
                    {
                        FName = "Roshdy",
                        LName = "Raghep",
                        Email = "roshdyraghep@gmail.com",
                        Password = "@Bdallah123",
                        User_Img = ImageData
                    }

            });
                context.SaveChanges();
            }
            if (!context.Movies.Any())
                {
                    
                    byte[] ImageData = null;
                    Image fileImage = Image.FromFile("C:/Users/roshd/Git-Hub/IMDB_201900461/IMDB/IMDB/Content/Images/img1.jpg");
                    ImageData = ImageConversion.ImageToByteArray(fileImage);
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Movie_Name = "DrStrange",
                            Movie_TLink = "https://www.youtube.com/embed/ORVShW0Yjaw",
                            Img = ImageData,
                            Director_ID = 2
                        },
                        new Movie()
                        {
                            Movie_Name = "asd",
                            Movie_TLink = "https://www.youtube.com/embed/ORVShW0Yjaw",
                            Img = ImageData,
                            Director_ID = 2
                        },
                        new Movie()
                        {
                            Movie_Name = "eqw",
                            Movie_TLink = "https://www.youtube.com/embed/ORVShW0Yjaw",
                            Img = ImageData,
                            Director_ID = 2
                        },
                        new Movie()
                        {
                            Movie_Name = "rqe",
                            Movie_TLink = "https://www.youtube.com/embed/ORVShW0Yjaw",
                            Img = ImageData,
                            Director_ID = 2
                        },


                    });
                    context.SaveChanges();
                } 
            }
        }
    }
}