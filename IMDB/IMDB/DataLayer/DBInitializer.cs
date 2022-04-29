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
            
            if (!context.Users.Any())
            {
                    Image fileImage = Image.FromFile("C:/Users/roshd/Git-Hub/IMDB_201900461/IMDB/IMDB/Content/Images/user.png");

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
                        Email = "abdallahelswify@gmail.com",
                        Password = "@Bdallah123",
                        User_Img = ImageData
                    }

            });
                context.SaveChanges();
            }
            if (context.Movies.Any())
                {
                    Director d = new Director();
                    d.Age = 21;
                    d.FName = "Director";
                    d.LName = "Roshdy";
                    
                    byte[] ImageData = null;
                    Image fileImage = Image.FromFile("C:/Users/roshd/Git-Hub/IMDB_201900461/IMDB/IMDB/Content/Images/47857.jpg");
                    ImageData = ImageConversion.ImageToByteArray(fileImage);
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Movie_Name = "DrStrange",
                            Movie_TLink = "https://www.youtube.com/embed/ORVShW0Yjaw",
                            Img = ImageData,
                            Director_ID = d
                        },
                        

                    });
                    context.SaveChanges();
                } 
            }
        }
    }
}