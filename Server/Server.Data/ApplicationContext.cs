﻿using Microsoft.EntityFrameworkCore;
using Server.Data.Classes;

namespace Server.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Todo> Todos { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>()
                .HasMany(t => t.Tags)
                .WithOne();
        }
    }
}