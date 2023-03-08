using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }
        public DbSet<MuscleGroup> ExerciseMuscleGroups { get; set; }
        public DbSet<MuscleGroup> WorkoutExercise { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExerciseMuscleGroup>()
                .HasKey(em => new { em.ExerciseId, em.MuscleGroupId });

            modelBuilder.Entity<ExerciseMuscleGroup>()
                .HasOne(em => em.Exercise)
                .WithMany(e => e.ExerciseMuscleGroups)
                .HasForeignKey(em => em.ExerciseId);

            modelBuilder.Entity<ExerciseMuscleGroup>()
                .HasOne(em => em.MuscleGroup)
                .WithMany(mg => mg.ExerciseMuscleGroups)
                .HasForeignKey(em => em.MuscleGroupId);

            modelBuilder.Entity<WorkoutExercise>()
                .HasKey(we => new { we.WorkoutId, we.ExerciseId });

            modelBuilder.Entity<WorkoutExercise>()
                .HasOne(we => we.Workout)
                .WithMany(w => w.WorkoutExercises)
                .HasForeignKey(we => we.WorkoutId);

            modelBuilder.Entity<WorkoutExercise>()
                .HasOne(we => we.Exercise)
                .WithMany(e => e.WorkoutExercises)
                .HasForeignKey(we => we.ExerciseId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}