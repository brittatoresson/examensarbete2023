using System;
using Examensarbete.Server.Interface;
using Examensarbete.Server.Models;
using Examensarbete.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace Examensarbete.Server.Services
{

    public class NyManager : INy
    {
        readonly DatabaseContextNy _dbContext = new();
        public NyManager(DatabaseContextNy dbContext)
        {
            _dbContext = dbContext;
        }
        //To Get all user details
        public List<Ny> GetUserDetails()
        {
            try
            {
                return _dbContext.Ny.ToList();
            }
            catch
            {
                throw;
            }
        }
        //To Add new user record
        public void AddUser(Ny user)
        {
            try
            {
                _dbContext.Ny.Add(user);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particluar user
        public void UpdateUserDetails(Ny user)
        {
            try
            {
                _dbContext.Entry(user).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //Get the details of a particular user
        public Ny GetUserData(int id)
        {
            try
            {
                Ny? user = _dbContext.Ny.Find(id);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
        //To Delete the record of a particular user
        public void DeleteUser(int id)
        {
            try
            {
                Ny? user = _dbContext.Ny.Find(id);
                if (user != null)
                {
                    _dbContext.Ny.Remove(user);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}