using Microsoft.EntityFrameworkCore;
using PasswordGenerator.Domain.Entities;
using System;
using System.Collections.Generic;

namespace PasswordGenerator.Database.Postgres.Context {
    public class PasswordGeneratorDbContext : DbContext {
        public PasswordGeneratorDbContext(DbContextOptions options) : base(options) {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PasswordNoteEntity> PasswordNotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<UserEntity>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<UserEntity>()
                .HasMany(u => u.PasswordNotes)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.User.Id);

            modelBuilder.Entity<PasswordNoteEntity>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<PasswordNoteEntity>()
                .HasOne(p => p.User)
                .WithMany(u => u.PasswordNotes)
                .HasForeignKey(p => p.UserId);
        }
    }
}
