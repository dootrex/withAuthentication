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
            var listings = from d in _context.Developers
                           from p in d.Projects
                           select new Project
                           {
                               ProjectId = p.ProjectId,
                               DeveloperId = d.DeveloperId,
                               StreetNum = p.StreetNum,
                               StreetName = p.StreetName,
                               City = p.City,
                               PostalCode = p.PostalCode,
                               ProjectStatus = p.ProjectStatus,
                               ProjectImage = p.ProjectImage,
                               Developer = p.Developer,
                               ProjectName = p.ProjectName,
                               ProjectLink = p.ProjectLink,
                               ProjectDescription = p.ProjectDescription,
                               Created = p.Created,
                               ExpectedCompletion = p.ExpectedCompletion
                           };
            return Ok(listings);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult getByID(long id)
        {
            var project = from d in _context.Developers
                          from p in d.Projects
                          .Where(p => p.ProjectId == id)
                          select new Project
                          {
                              ProjectId = p.ProjectId,
                              DeveloperId = d.DeveloperId,
                              StreetNum = p.StreetNum,
                              StreetName = p.StreetName,
                              City = p.City,
                              PostalCode = p.PostalCode,
                              ProjectStatus = p.ProjectStatus,
                              ProjectImage = p.ProjectImage,
                              Developer = p.Developer,
                              ProjectName = p.ProjectName,
                              ProjectLink = p.ProjectLink,
                              ProjectDescription = p.ProjectDescription,
                              Created = p.Created,
                              ExpectedCompletion = p.ExpectedCompletion,
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
