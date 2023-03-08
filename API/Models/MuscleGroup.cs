using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    public class MuscleGroup
    {
        public int MuscleGroupId { get; set; }
        public string MuscleGroupName { get; set; }
        [JsonIgnore]
        public ICollection<ExerciseMuscleGroup> ExerciseMuscleGroups { get; set; }
    }
}