using System;
using Microsoft.AspNetCore.Mvc;
using Examensarbete.Shared.Model;
using Examensarbete.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace Examensarbete.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly DataContext _context;

        public TestController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ExerciseModel>>> GetData()
        {
            var exerciseList = await _context.Exercises.ToListAsync();
            return Ok(exerciseList);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ExerciseModel>> GetData(int id)
        {
            var exercise = await _context.Exercises.FirstOrDefaultAsync(e => e.ID == id);
            if (exercise == null)
            {
                return NotFound("sorry...");
            }

            return Ok(exercise);
        }

        //[HttpPost]
        //public async Task<ActionResult<ExerciseModel>> CreateWorkout(ExerciseModel workout)
        //{
        //    _context.Exercises.Add(workout);
        //    await _context.SaveChangesAsync();
        //    //return Ok(workout);
        //    return Ok(await GetData());
        //}

    }
}
