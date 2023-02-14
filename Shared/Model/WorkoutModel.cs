using System;
namespace Examensarbete.Shared.Model
{
    public class WorkoutModel
    {
        public int ID { get; set; }
        public string Exercise { get; set; }
        ExerciseModel exercise { get; set; }
        List<ExerciseModel> exerciseList { get; set; }
        public int TotalTime { get; set; }
        public int Rounds { get; set; }
        public int Repetitions { get; set; }
        public DateTime Date { get; set; } = DateTime.Today;
        //public string Type { get; set; }
    }
}
