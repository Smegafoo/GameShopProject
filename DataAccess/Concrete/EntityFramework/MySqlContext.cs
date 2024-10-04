using Entities.Concrete;
using Entities.Constants;
using Entities.Relation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class MySqlContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"server=localhost;database=GameShopProject;User=root;Password=Smegafoo;",
                new MySqlServerVersion(new Version(8, 0, 37)),
                options => options.EnableRetryOnFailure(
                   maxRetryCount: 5,
                   maxRetryDelay: System.TimeSpan.FromSeconds(30),
                   errorNumbersToAdd: null
                ));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LibraryGames>().HasKey(p => new { p.GameLibraryId, p.GameId});

            modelBuilder.Entity<Admin>()
                .Property(e => e.AdminLevel)
                .HasConversion(
                v => v.ToString(),
                v => (Authority)Enum.Parse(typeof(Authority), v)
                );

        }

       

        public DbSet<Game> Games { get; set; }
        public DbSet<GameReview> GameReviews { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<LibraryGames> LibraryGames { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<GameLibrary> gameLibraries { get; set; }




        
    }
}

