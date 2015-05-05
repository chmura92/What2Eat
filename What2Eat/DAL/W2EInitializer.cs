using System;
using System.Collections.Generic;
using System.Data.Entity;
using What2Eat.Models;

namespace What2Eat.DAL
{
        public class W2EInitializer : DropCreateDatabaseAlways<W2EContext>  // niszczy baze przy kazdym uruchomieniu, do zmienienia pozniej
        {
            protected override void Seed(W2EContext context)
            {
                SeedW2ElData(context);
                base.Seed(context);
            }

            private void SeedW2ElData(W2EContext context) // wypelnienie danymi poczatkowymi
            {
            //    var Users = new List<User>
            //{//a
            //    new User() {Login = "Marian", Password = "inne"},
            //    new User() {Login = "Kumalski", Password = "Jeszcze inne"}
            //};
            //    Users.ForEach(a => context.Users.Add(a));
            //    context.SaveChanges();
            }

        } 
    }