using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using withAuthentication.Models;

namespace withAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private PThreeDbContext _context;
        public HomeController(PThreeDbContext context) { _context = context; }

        [HttpGet]
        public IActionResult getAllListings()
        {
            var listings = (from d in _context.Developers
                            from p in d.Projects
                            where d.DeveloperId == p.DeveloperId
                            select new
                            {
                                Project = p,
                                Developer = d
                            }).ToList();
            return Ok(listings);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult getByID(long id)
        {
            var project = from d in _context.Developers
                          from p in d.Projects
                          where p.ProjectId == id
                          where d.DeveloperId == p.DeveloperId
                          select new
                          {
                              Project = p,
                              Developer = d
                          };
            return Ok(project);
        }

        [HttpGet]
        [Route("developerName/{query}")]
        public IActionResult getByDeveloperName(string query)
        {
            return Ok(_context.Projects.Where(p => p.Developer.DeveloperName.Contains(query)));
        }
        [HttpGet]
        [Route("city/{query}")]
        public IActionResult getByCity(string query)
        {
            return Ok(_context.Projects.Where(p => p.City.Contains(query)));
        }
        [HttpGet]
        [Route("status/{query}")]
        public IActionResult getByProjectStatus(string query)
        {
            return Ok(_context.Projects.Where(p => p.ProjectStatus == query));
        }
    }

}
