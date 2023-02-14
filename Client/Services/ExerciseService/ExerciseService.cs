using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using Examensarbete.Shared;
using Examensarbete.Shared.Model;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;
using static Examensarbete.Client.Pages.PickExercisePage;

namespace Examensarbete.Client.Services.ExerciseService
{
    public class ExerciseService : IExerciseService
    {
        private readonly HttpClient _http;

        public ExerciseService(HttpClient http)
        {
            _http = http;
        }

        public List<ExerciseModel>? ExerciseList { get; set; } = new();
        public ExerciseModel? Exercise { get; set; } = new();

        public async Task<ExerciseModel> GetSingelEx(int id)
        {
            Exercise = await _http.GetFromJsonAsync<ExerciseModel>($"api/test/{id}");
            if (Exercise != null)
                return Exercise;
            throw new Exception("Hero not found!");
        }

        public async Task GetExercises()
        {
            var result = await _http.GetFromJsonAsync<List<ExerciseModel>>("api/test");
            ExerciseList = result;
        }

        public async Task CreateWorkout(List<ExerciseModel> exercise)
        {
            var result = await _http.PostAsJsonAsync("api/test", exercise);
            var response = await result.Content.ReadFromJsonAsync<ExerciseModel>();
            Exercise = response;
        }

        //WorkoutModel workout = new();
        public async Task CreateWorkout(ExerciseModel exercise)
        {
            //var result = await _http.PostAsJsonAsync("api/test", workout);
            //var content = await result.Content.ReadFromJsonAsync<ExerciseModel>();
            //Exercise = response;
        }
    }
}
