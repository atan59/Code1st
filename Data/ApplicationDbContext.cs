using System;
using System.Collections.Generic;
using System.Text;
using Code1st.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Code1st.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        // Will become tables in the database
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Creates sample data
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            
            // Here is where we can seed the tables with sample data.
            // If "Team" is empty, populate with data.
            modelBuilder.Entity<Team>().HasData(SampleData.GetTeams());
            // If "Player" is empty, populate with data.
            modelBuilder.Entity<Player>().HasData(SampleData.GetPlayers());
        }
    }
}
