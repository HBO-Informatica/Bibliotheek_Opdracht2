using Syntheseopdracht2.Model;
using System;
using System.Data.Entity;

namespace Syntheseopdracht2.DA
{
    public class BoekenDatabase : DbContext, IBoekenDatabase
    {
        private static readonly String _connectionString = "ConfigDB";
        //ConfigDB

        public DbSet<Boek> Boeken { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public BoekenDatabase() : base(_connectionString)
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boek>().ToTable("Boeken");
            modelBuilder.Entity<Genre>().ToTable("Genres");
            base.OnModelCreating(modelBuilder);
        }
    }
}
