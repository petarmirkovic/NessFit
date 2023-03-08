using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    public class Exercise
    {
        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public string ExerciseDescription { get; set; }
        [JsonIgnore]
        public ICollection<ExerciseMuscleGroup> ExerciseMuscleGroups { get; set; }
        [JsonIgnore]
        public ICollection<WorkoutExercise> WorkoutExercises { get; set; }
    }
}