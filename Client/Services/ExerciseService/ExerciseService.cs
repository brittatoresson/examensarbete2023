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

        public List<WorkoutModel>? WorkoutList { get; set; } = new();
        public List<ExerciseModel>? ExerciseList { get; set; } = new();
        public ExerciseModel? Exercise { get; set; } = new();
        public WorkoutModel? Workout { get; set; } = new();

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

            public async Task GetWorkout()
        {
            var result = await _http.GetFromJsonAsync<List<WorkoutModel>>("api/workout");
            WorkoutList = result;
        }

        public async Task CreateWorkout(WorkoutModel workout)
        {
            var result = await _http.PostAsJsonAsync("api/workout", workout);
            var response = result.StatusCode;
        }

        public async Task DeleteWorkout(int? id)
        {
            //Googla detta tack
            var uri = $"api/workout/{id}";

            var result = await _http.DeleteAsync(uri);
            var response = result.StatusCode;
        }
    }
}
