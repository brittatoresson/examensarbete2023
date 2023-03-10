using System;
using Examensarbete.Shared.Model;

namespace Examensarbete.Client.Pages
{
	public partial class SavedWorkouts
	{
        string? comment;
        int? Id;
        bool showMinutes;

        protected override async Task OnInitializedAsync()
        {
            await exerciseService.GetWorkout();
        }

        public async Task GetWorkout()
        {
            await exerciseService.GetWorkout();
            StateHasChanged();
        }

        public async void Delete(int? id)
        {
            await exerciseService.DeleteWorkout(id);
            GetWorkout();
        }

        public void UpdateNotes(int? id)
        {
            Id = id;
            showMinutes = !showMinutes;
            comment = string.Empty;
        }

        public async Task UpdateExercise(WorkoutModel workout, string comment)
        {
            workout.Comment = comment;
            await exerciseService.UpdateExercise(workout);
            Id = 0;
        }
    }
}

