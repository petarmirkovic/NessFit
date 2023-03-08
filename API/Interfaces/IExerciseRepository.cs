using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Interfaces
{
    public interface IExerciseRepository
    {
        Exercise GetById(int id);
        IEnumerable<Exercise> GetByMuscleGroupId(int muscleGroupId);
        bool Exists(int id);
        bool Save();
        bool Add(Exercise exercise);
        bool Update(Exercise exercise);
        bool Delete(Exercise exercise);
    }
}