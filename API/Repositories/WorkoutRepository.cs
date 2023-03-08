using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly DataContext _context;

        public WorkoutRepository(DataContext context)
        {
            _context = context;
        }

        public Workout GetById(int id)
        {
            return _context.Workouts.FirstOrDefault(w => w.WorkoutId == id);
        }

        public bool Exists(int id)
        {
            return _context.Workouts.Any(w => w.WorkoutId == id);
        }

        public bool Add(Workout workout)
        {
            _context.Workouts.Add(workout);
            return Save();
        }

        public bool Update(Workout workout)
        {
            _context.Workouts.Update(workout);
            return Save();
        }

        public bool Delete(Workout workout)
        {
            _context.Workouts.Remove(workout);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }

        public IEnumerable<Workout> GetByUserId(int userId)
        {
            return _context.Workouts.Where(w=>w.UserId==userId);
        }
    }

}