using System;
using Examensarbete.Shared.Model;

namespace Examensarbete.Server.Interface
{
    public interface INy
    {
        public List<Ny> GetUserDetails();
        public void AddUser(Ny user);
        public void UpdateUserDetails(Ny user);
        public Ny GetUserData(int id);
        public void DeleteUser(int id);
    }
}