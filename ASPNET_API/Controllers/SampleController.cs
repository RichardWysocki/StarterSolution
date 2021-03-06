﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_API.Controllers
{
    [Produces("application/json")]
    [Route("api/Sample")]
    public class SampleController : ControllerBase
    {

        [HttpGet(), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public string Get()
        {
            return "Get value";
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"value: {id}";
        }
    }
}