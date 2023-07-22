﻿using Authentication.API.Dtos;
using Authentication.API.Security;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.API.Controllers
{
    [Route("/AuthModule")]
    public class UserController : ControllerBase
    {
        private readonly JwtCreator _jwtCreator;

        public UserController(JwtCreator jwtCreator)
        {
            _jwtCreator = jwtCreator;
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Post([FromBody] LoginRequest request)
        {
            if (request.UserName == "admin")
                return Ok(_jwtCreator.GenerateJsonWebToken("admin"));
            return Unauthorized();
        }
    }
}