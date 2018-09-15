using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SEDC.PractialAspNet.WebDemo.Models;
using SEDC.PracticalAspNet.Data.Model;

namespace SEDC.PracticalAspNet.Data
{
    public class RestaurantContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public Database Database => base.Database;
        public int SaveChanges()
        {
            return base.SaveChanges();
        }
        public RestaurantContext() 
            : base("name=RestaurantConnection")
        {
        }

        public static RestaurantContext Create()
        {
            return new RestaurantContext();
        }
    }
}