using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Examensarbete.Shared.Model
{
    public class WorkoutModel
    {
        public int? id { get; set; }
        //public string? Exercise { get; set; }
        public int? TotalTime { get; set; }
        public int? Rounds { get; set; }
        //public int? Repetition { get; set; }
        public DateTime? Date { get; set; } = DateTime.Today;
        public int? WorkoutModelid { get; set; }
        public List<ExercisesListModel>? Exercises { get; set; }
        public string? Focus { get; set; }
        public int? IntervallOn { get; set; }
        public int? IntervallOff { get; set; }
        public string? Comment { get; set; }
    }
}
