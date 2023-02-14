using System;
using Examensarbete.Shared.Model;

namespace Examensarbete.Server.Interface
{
    public interface INy
    {
        public List<NyWorkoutModel> GetUserDetails();
        public void AddUser(NyWorkoutModel user);
        public void UpdateUserDetails(NyWorkoutModel user);
        public NyWorkoutModel GetUserData(int id);
        public void DeleteUser(int id);
    }
}