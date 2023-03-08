using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Interfaces;
using API.Models;

namespace API.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly DataContext _context;

        public ExerciseRepository(DataContext context)
        {
            _context = context;
        }

        public Exercise GetById(int id)
        {
            return _context.Exercises.FirstOrDefault(e => e.ExerciseId == id);
        }

        public IEnumerable<Exercise> GetByMuscleGroupId(int muscleGroupId)
        {
            var id = _context.ExerciseMuscleGroups
                .Where(emg => emg.MuscleGroupId == muscleGroupId)
                .Select(emg => emg.MuscleGroupId).ToList();
            List<Exercise> exercises = new List<Exercise>();
            foreach (int i in id)
            {
                exercises.Append(GetById(i));
            }
            return exercises;
        }

        public bool Exists(int id)
        {
            return _context.Exercises.Any(e => e.ExerciseId == id);
        }

        public bool Add(Exercise exercise)
        {
            _context.Exercises.Add(exercise);
            return Save();
        }

        public bool Update(Exercise exercise)
        {
            _context.Exercises.Update(exercise);
            return Save();
        }

        public bool Delete(Exercise exercise)
        {
            _context.Exercises.Remove(exercise);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}