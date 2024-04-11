using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using HakatonPIVATON.Entity.Date;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using HakatonPIVATON.Data.Entities;

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
        public DbSet<HistoryStatuses> HistoryStatuses { get; set; } = null!;

        public DbSet<Locality> Locality { get; set; } = null!;
        public DbSet<OdersGoods> OdersGoods { get; set; } = null!;
        public DbSet<Order> Order { get; set; } = null!;
        public DbSet<Point> Point { get; set; } = null!;
        public DbSet<Date.Route> Route { get; set; } = null!;
        public DbSet<Status> Status { get; set; } = null!;
        public DbSet<User> User { get; set; } = null!;
        public DbSet<UserInfo> UserInfo { get; set; } = null!;
        public DbSet<UsersGoods> UsersGoods { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Date.Route>()
            .HasOne(r => r.FirstPoint)
            .WithMany(p => p.FirstPoint)
            .HasForeignKey(r => r.FirstPointId);

            modelBuilder.Entity<Date.Route>()
                .HasOne(r => r.SecondPoint)
                .WithMany(p => p.SecondPoint)
                .HasForeignKey(r => r.SecondPointId);

            // Добавляем конфигурацию для сущности Order
            modelBuilder.Entity<Order>()
                .HasOne(o => o.StartPoint)
                .WithMany(p => p.StartPoint)
                .HasForeignKey(o => o.StartPointID);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.EndPoint)
                .WithMany(p => p.EndPoint)
                .HasForeignKey(o => o.EndPointID);
            base.OnModelCreating(modelBuilder);
        }
    }
    }
