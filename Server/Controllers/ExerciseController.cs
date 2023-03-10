using System;
using Microsoft.AspNetCore.Mvc;
using Examensarbete.Shared.Model;
using Examensarbete.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace Examensarbete.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly DataContext _context;

        public ExerciseController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ExerciseModel>>> GetData()
        {
            var exerciseList = await _context.Exercises.ToListAsync();
            return Ok(exerciseList);
        }
    }
}
