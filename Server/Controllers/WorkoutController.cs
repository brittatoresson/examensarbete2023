using System;
using Examensarbete.Server.Interface;
using Examensarbete.Shared.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Examensarbete.Server.Models;
using Examensarbete.Server.Data;

// FKYTTA IN ALL DATA FRÅN NyManager HIT?? Gör databas-call här...?
namespace Examensarbete.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    //public class NyController : ControllerBase
    {
        //private readonly INyManager _INy;
        //public NyController(INyManager iNy)
        //{
        //    _INy = iNy;
        //}

        //[HttpGet]
        //public async Task<List<WorkoutModel>> Get()
        //{
        //    var hej = await Task.FromResult(_INy.GetSavedWorkouts());
        //    return hej;
        //}

        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    WorkoutModel ny = _INy.GetUserData(id);
        //    if (ny != null)
        //    {
        //        return Ok(ny);
        //    }
        //    return NotFound();
        //}
        //[HttpPost]
        //public void Post(WorkoutModel ny)
        //{
        //    _INy.AddWorkout(ny);
        //}

        //[HttpPut]
        //public void Put(WorkoutModel ny)
        //{
        //    _INy.UpdateUserDetails(ny);
        //}
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    _INy.DeleteUser(id);
        //    return Ok();
        //}



        private readonly DatabaseContextNy _context;

        public WorkoutController(DatabaseContextNy context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<WorkoutModel>>> GetData()
        {
            var workouts = await _context.Ny.ToListAsync();
            return workouts;
        }

        [HttpPost]
        public void Post(WorkoutModel workout)
        {
            _context.Ny.Add(workout);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            WorkoutModel workout = _context.Ny.Where(x => x.id.Equals(id)).FirstOrDefault();

            if (workout != null)
            {
                _context.Ny.Remove(workout);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException();
            }

        }
    }
}
