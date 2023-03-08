using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Interfaces;
using API.Models;

namespace API.Repositories
{
    public class MuscleGroupRepository : IMuscleGroupRepository
    {
        private readonly DataContext _context;

        public MuscleGroupRepository(DataContext context)
        {
            _context = context;
        }

        public MuscleGroup GetById(int id)
        {
            return _context.MuscleGroups.FirstOrDefault(mg => mg.MuscleGroupId == id);
        }

        public bool Exists(int id)
        {
            return _context.MuscleGroups.Any(mg => mg.MuscleGroupId == id);
        }

        public bool Add(MuscleGroup muscleGroup)
        {
            _context.MuscleGroups.Add(muscleGroup);
            return Save();
        }

        public bool Update(MuscleGroup muscleGroup)
        {
            _context.MuscleGroups.Update(muscleGroup);
            return Save();
        }

        public bool Delete(MuscleGroup muscleGroup)
        {
            _context.MuscleGroups.Remove(muscleGroup);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }
    }

}