using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class ExerciseMuscleGroup
    {
        public int MuscleGroupId { get; set; }
        public int ExerciseId { get; set; }
        public MuscleGroup MuscleGroup { get; set; }
        public Exercise Exercise { get; set; }
    }
}