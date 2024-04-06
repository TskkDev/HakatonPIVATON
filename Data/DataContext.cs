﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using HakatonPIVATON.Entity.Date;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace HakatonPIVATON.Entity
{
    public sealed class DataContext : IdentityDbContext<User, IdentityRole<long>, long>
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
            Database.Migrate();
        }
        public DbSet<Good> Good { get; set; } = null!;
        public DbSet<Locality> Locality { get; set; } = null!;
        public DbSet<OdersGoods> OdersGoods { get; set; } = null!;
        public DbSet<Order> Order { get; set; } = null!;
        public DbSet<OrdersLocalities> OrdersLocalities { get; set; } = null!;
        public DbSet<Point> Point { get; set; } = null!;
        public DbSet<Date.Route> Route { get; set; } = null!;
        public DbSet<User> User { get; set; } = null!;
        public DbSet<UsersGoods> UsersGoods { get; set; } = null!;
    }
}
