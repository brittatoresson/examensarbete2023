using System;
using Examensarbete.Server.Interface;
using Examensarbete.Shared.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Examensarbete.Server.Models;

// FKYTTA IN ALL DATA FRÅN NyManager HIT?? Gör databas-call här...?
namespace Examensarbete.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NyController : ControllerBase
    {
        private readonly INyManager _INy;
        public NyController(INyManager iNy)
        {
            _INy = iNy;
        }

        [HttpGet]
        public async Task<List<WorkoutModel>> Get()
        {
            var hej = await Task.FromResult(_INy.GetSavedWorkouts());
            return hej;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            WorkoutModel ny = _INy.GetUserData(id);
            if (ny != null)
            {
                return Ok(ny);
            }
            return NotFound();
        }
        [HttpPost]
        public void Post(WorkoutModel ny)
        {
            _INy.AddWorkout(ny);
        }

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
    }
}