using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using What2Eat.Models;

namespace What2Eat.DAL
{
    public class W2EContext : DbContext
    {
        public W2EContext() : base("W2EContext") { }

        public DbSet<LikedProduct> LikedProducts { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAtributes> UserAtributes { get; set; }
        
    }
}