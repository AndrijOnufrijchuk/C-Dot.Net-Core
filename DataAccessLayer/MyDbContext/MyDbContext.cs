using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer.DbContext1
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        public MyDbContext()
        {

        }
      public  DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .HasKey(p => p.id);
            modelBuilder.Entity<Student>()
                .Property(p => p.name)
                .HasMaxLength(50);
            modelBuilder.Entity<Student>()
                .HasOne<Group>()
                .WithMany()
                .HasForeignKey(p => p.GroupId);

        }
    }
}
