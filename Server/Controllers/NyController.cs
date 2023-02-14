﻿using System;
using Examensarbete.Server.Interface;
using Examensarbete.Shared.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Examensarbete.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NyController : ControllerBase
    {
        private readonly INy _INy;
        public NyController(INy iNy)
        {
            _INy = iNy;
        }
        [HttpGet]
        public async Task<List<NyWorkoutModel>> Get()
        {
            return await Task.FromResult(_INy.GetUserDetails());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            NyWorkoutModel ny = _INy.GetUserData(id);
            if (ny != null)
            {
                return Ok(ny);
            }
            return NotFound();
        }
        [HttpPost]
        public void Post(NyWorkoutModel ny)
        {
            _INy.AddUser(ny);
        }
        [HttpPut]
        public void Put(NyWorkoutModel ny)
        {
            _INy.UpdateUserDetails(ny);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _INy.DeleteUser(id);
            return Ok();
        }
    }
}