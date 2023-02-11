using System;
using Examensarbete.Server.Data;
using Examensarbete.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace Examensarbete.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SaveController : Controller
    {
        private readonly SaveContext _context;

        public SaveController(SaveContext context)
        {
            _context = context;
        }

        [HttpPost("post")]
        public async Task<ActionResult<ExerciseModel>> CreateWorkout(WorkoutModel workout)
        {
            _context.Workout.Add(workout);
            await _context.SaveChangesAsync();
            return Ok(workout);
        }

    }
}

