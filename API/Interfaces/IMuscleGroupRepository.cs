using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Interfaces
{
    public interface IMuscleGroupRepository
    {
        MuscleGroup GetById(int id);
        bool Exists(int id);
        bool Save();
        bool Add(MuscleGroup muscleGroup);
        bool Update(MuscleGroup muscleGroup);
        bool Delete(MuscleGroup muscleGroup);
    }
}