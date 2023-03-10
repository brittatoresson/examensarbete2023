using System.Net.Http;
using System.Net.Http.Json;
using Examensarbete.Shared.Model;

namespace Examensarbete.Client.Services.ExerciseService
{
    public class ExerciseService : IExerciseService
    {
        private readonly HttpClient _http;

        public ExerciseService(HttpClient http)
        {
            _http = http;
        }

        public List<WorkoutModel>? WorkoutList = new List<WorkoutModel>();
        public List<ExerciseModel>? ExerciseList { get; set; } = new();
        public ExerciseModel? Exercise { get; set; } = new();
        public WorkoutModel? Workout { get; set; } = new();
        public int statusCode;

        public async Task<ExerciseModel> GetSingelEx(int id)
        {
            Exercise = await _http.GetFromJsonAsync<ExerciseModel>($"api/test/{id}");
            if (Exercise != null)
                return Exercise;
            throw new Exception("Not found!");
        }

        public async Task GetExercises()
        {
            var result = await _http.GetFromJsonAsync<List<ExerciseModel>>("api/exercise");
            ExerciseList = result;
        }

        public async Task<List<WorkoutModel>?> GetWorkout()
        {
            var result = await _http.GetFromJsonAsync<List<WorkoutModel>>("api/workout");
            WorkoutList = result;
            return WorkoutList;
        }

        public async Task CreateWorkout(WorkoutModel workout)
        {
            var result = await _http.PostAsJsonAsync("api/workout", workout);
             statusCode = (int)result.StatusCode;
        }

        public async Task DeleteWorkout(int? id)
        {
            var uri = $"api/workout/{id}";
            var result = await _http.DeleteAsync(uri);
            statusCode = (int)result.StatusCode;
        }

        public async Task UpdateExercise(WorkoutModel workout)
        {
            var result = await _http.PutAsJsonAsync($"api/workout", workout);
            statusCode = (int)result.StatusCode;
        }
    }
}
