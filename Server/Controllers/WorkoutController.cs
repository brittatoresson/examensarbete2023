using System;
using Examensarbete.Server.Interface;
using Examensarbete.Shared.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Examensarbete.Server.Models;
using Examensarbete.Server.Data;

namespace Examensarbete.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly DatabaseContextNy _context;

        public WorkoutController(DatabaseContextNy context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<WorkoutModel>>> GetData()
        {
            var exercise = await _context.ExercisesList.ToListAsync();
            List<WorkoutModel>? workouts = new();

             workouts = await _context.Workout.ToListAsync();
            foreach (var item in exercise)
            {
                //var workout = await _context.Ny.Where(x => x.id.Equals(item.WorkoutModelid)).FirstOrDefaultAsync();
                //if (workout != null)
                //{
                //    workouts.Add(workout);
                //}
            }
            return Ok(workouts);
        }

        [HttpPost]
        public void Post(WorkoutModel workout)
        {
            ExercisesListModel exercises = new();
            foreach (var item in workout.Exercises)
            {
                exercises = item;
                _context.ExercisesList.Add(exercises);
                _context.SaveChanges();
            }

            _context.Workout.Add(workout);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            WorkoutModel workout = _context.Workout.Where(x => x.id.Equals(id)).FirstOrDefault();

            if (workout != null)
            {
                _context.Workout.Remove(workout);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException();
            }

        }
    }
}
