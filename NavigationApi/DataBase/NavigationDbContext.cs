using Microsoft.EntityFrameworkCore;
using NavigationApi.DataBase.Enums;
using NavigationApi.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NavigationApi.DataBase
{
	public class NavigationDbContext:DbContext
	{
        public DbSet<Street> Streets { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<Policeman> Policemans { get; set; }
        public DbSet<RoadType> RoadTypes { get; set; }

        public NavigationDbContext(DbContextOptions<NavigationDbContext> options) 
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Policeman>()
                .Property(e => e.PolicemanMood)
                .HasConversion(
                    v => v.ToString(),
                    v => (PolicemanMood)Enum.Parse(typeof(PolicemanMood), v));

            modelBuilder
                .Entity<Car>()
                .HasIndex(p => p.Mark)
                .IsUnique();

            modelBuilder
               .Entity<Driver>()
               .HasIndex(p => p.FullName)
               .IsUnique();

            modelBuilder
               .Entity<Fuel>()
               .HasIndex(p => p.Name)
               .IsUnique();

            modelBuilder
               .Entity<RoadType>()
               .HasIndex(p => p.Name)
               .IsUnique();

            modelBuilder
               .Entity<Street>()
               .HasIndex(p => p.Name)
               .IsUnique();

            modelBuilder.Entity<Street>().HasData(
                new Street
                {
                    Id = Guid.NewGuid(),
                    Name = "ул. Гагарина",
                    Length = 5000
                },
                new Street
                {
                    Id = Guid.NewGuid(),
                    Name = "ул. Пушкина",
                    Length = 1000
                },
                new Street
                {
                    Id = Guid.NewGuid(),
                    Name = "ул. Солнечная",
                    Length = 3000
                },
                new Street
                {
                    Id = Guid.NewGuid(),
                    Name = "ул. Аминева",
                    Length = 4000
                },
                new Street
                {
                    Id = Guid.NewGuid(),
                    Name = "ул. Ново-садовая",
                    Length = 4000
                }
            );
        }
    }
}
