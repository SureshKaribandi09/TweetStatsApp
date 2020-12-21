using Microsoft.EntityFrameworkCore;
using System;
using TweetStats.Data.Models;

namespace TweetStats.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions opts) : base(opts)
        {

        }

        #region Properties
        public DbSet<Stat> Stats { get; set; }
        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Stat>().ToTable("Stats");
            modelBuilder.Entity<Stat>().Property(s => s.Id).ValueGeneratedOnAdd();


        }
        #endregion
    }
}
