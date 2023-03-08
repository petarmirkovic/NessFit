using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Interfaces
{
    public interface IWorkoutRepository
    {
        Workout GetById(int id);
        IEnumerable<Workout> GetByUserId(int userId);
        bool Exists(int id);
        bool Save();
        bool Add(Workout workout);
        bool Update(Workout workout);
        bool Delete(Workout workout);
    }
}