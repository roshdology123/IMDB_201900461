using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using IMDB.Models;

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
                context.Users.AddRange(new List<User>()
                {
                    new User()
                    {
                        FName = "Abdallah",
                        LName = "Roshdy",
                        Email = "abdallahelswify@gmail.com",
                        Password = "@Bdallah123",
                        User_Img = System.Text.Encoding.ASCII.GetBytes("0xe04fd020ea3a6910a2d808002b30309d")
            }
                    
            });
                context.SaveChanges();
            }
            }
        }
    }
}