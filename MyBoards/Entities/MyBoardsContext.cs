using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Metrics;
using System;

namespace MyBoards.Entities
{
    public class MyBoardsContext : DbContext
    {
        public MyBoardsContext(DbContextOptions<MyBoardsContext> options) : base(options) 
        {
        }    
        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<User>  Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Adress> Adresses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkItem>()
                .Property(x => x.State)
                .IsRequired();
            modelBuilder.Entity<WorkItem>()
                .Property(x => x.Area)
                .HasColumnType("varchar(200)");
            modelBuilder.Entity<WorkItem>(eb =>
            {
                eb.Property(wi => wi.IterationPath)
            });
        }

    }
}
