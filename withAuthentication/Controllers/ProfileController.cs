using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace withAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCars()
        {
            List<string> carList = new List<string>() { "maserati", "mercedes" };
            return Ok(carList);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Developer")]
        [HttpGet]
        [Route("developerTest")]
        public IActionResult GetFruitsAuth()
        {
            List<string> carList = new List<string>() { "toyoto", "kia" };
            var identity = HttpContext.User.Identity;
            return Ok(carList);
        }
    }
}
