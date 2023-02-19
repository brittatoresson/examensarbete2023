using System;
using Examensarbete.Shared.Model;

namespace Examensarbete.Server.Interface
{
    public interface INyManager
    {
        public List<WorkoutModel> GetSavedWorkouts();
        public void AddWorkout(WorkoutModel user);
        public void UpdateUserDetails(WorkoutModel user);
        public WorkoutModel GetUserData(int id);
        public void DeleteUser(int id);
    }
}