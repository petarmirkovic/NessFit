using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    public class Workout
    {
        public int WorkoutId { get; set; }
        public string WorkoutName { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public User User { get; set; }
        [JsonIgnore]
        public ICollection<WorkoutExercise> WorkoutExercises { get; set; }
    }
}