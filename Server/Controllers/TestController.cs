using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Examensarbete.Shared.Model;
using Examensarbete.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace Examensarbete.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
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

        [HttpPost]
        public async Task<ActionResult<List<ExerciseModel>>> CreateSuperHero(ExerciseModel hero)
        {

            //hero = null;
            _context.Exercises.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await GetData());
        }



    }
}
