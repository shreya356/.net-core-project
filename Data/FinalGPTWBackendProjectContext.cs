using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalGPTWBackendProject.Models;
using FinalGPTWBackendProject.ViewModel;

namespace FinalGPTWBackendProject.Data
{
    public class FinalGPTWBackendProjectContext : DbContext
    {
        public FinalGPTWBackendProjectContext()
        {
        }

        public FinalGPTWBackendProjectContext (DbContextOptions<FinalGPTWBackendProjectContext> options)
            : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<FinalGPTWBackendProject.Models.Users> Users { get; set; }

        public DbSet<FinalGPTWBackendProject.Models.Students> Students { get; set; }

        public DbSet<FinalGPTWBackendProject.Models.Teachers> Teachers { get; set; }

        public DbSet<FinalGPTWBackendProject.Models.Attendance> Attendance { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer("Server=.;Database=AttendanceSystem;Trusted_Connection=True;");
            }
        }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Name)
                .HasColumnName("Name");

                entity.Property(e => e.Password)
                .HasColumnName("Password");

                entity.Property(e => e.Role)
                .HasColumnName("Role");


            

            });

            modelBuilder.Entity<Students>(entity =>
            {
                
                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_UsersId");

            });


            modelBuilder.Entity<Teachers>(entity =>
            {
                entity.HasOne(d => d.Users)
                    .WithMany(p => Teachers)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_UsersId");
            });


            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.HasOne(d => d.Users)
                    .WithMany(p => Attendance)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_UsersId");
            });





        }    
    
    
    
    }
}
