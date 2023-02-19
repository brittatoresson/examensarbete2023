using System;
using Examensarbete.Shared.Model;

namespace Examensarbete.Client.Services.ExerciseService
{
    public interface IExerciseService
    {
        List<ExerciseModel> ExerciseList { get; set; }
        Task GetExercises();
        Task<ExerciseModel> GetSingelEx(int id);
        Task CreateWorkout(WorkoutModel exercise);
        //Task CreateWorkout(ExerciseModel exercise);
        //Task CreateWorkout(List<ExerciseModel> exercise);
    }
}
