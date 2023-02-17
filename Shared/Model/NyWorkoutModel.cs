using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Examensarbete.Shared.Model

{
    public class NyWorkoutModel
    {
        public int? id { get; set; }
        public string? Exercise { get; set; }
        //ExerciseModel exercise { get; set; }
        //List<ExerciseModel> exerciseList { get; set; }
        public int? TotalTime { get; set; }
        public int? Rounds { get; set; }
        public int? Repetition { get; set; }
        public DateTime? Date { get; set; } = DateTime.Today;
        public string? Focus { get; set; }
    }
}
