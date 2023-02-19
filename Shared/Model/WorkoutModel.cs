using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examensarbete.Shared.Model
{
    public class WorkoutModel
    {
        public int? id { get; set; }
        public string? Exercise { get; set; }
        public int? TotalTime { get; set; }
        public int? Rounds { get; set; }
        public int? Repetition { get; set; }
        public DateTime? Date { get; set; } = DateTime.Today;
        //Extra
        //public List<string>? ExerciseList { get; set; }
        public string? Focus { get; set; }
        public int? IntervallOn { get; set; }
        public int? IntervallOff { get; set; }
    }
}
