using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using withAuthentication.Models;
using withAuthentication.ViewModels;

namespace withAuthentication.Controllers
{
    [Authorize(Roles = "Developer")]
    [Route("api/[controller]")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        private PThreeDbContext _context;
        public ListingController(PThreeDbContext context) { _context = context; }


        [HttpGet]
        public IActionResult GetAllListingsByDeveloperID()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string userName = "";
            if (identity != null)
            {
                userName = GetUserName(identity);
            }
            var developer = _context.Developers.Where(d => d.Email == userName).FirstOrDefault();
            if (developer != null)
            {
                var projects = _context.Projects.Where(p => p.DeveloperId == developer.DeveloperId).Select(p => new { Project = p, Developer = p.Developer });

                return Ok(projects);
            }
            else
            {
                return null;
            }
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetListingByID(long id)
        {
            var project = _context.Projects.Where(p => p.ProjectId == id).Select(p => new { Project = p, Developer = p.Developer });
            return Ok(project);
        }

        [HttpPost]
        public IActionResult CreateListing([FromBody] Project project)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string userName = "";
            if (identity != null)
            {
                userName = GetUserName(identity);
            }
            var developer = _context.Developers.Where(d => d.Email == userName).FirstOrDefault();
            if (project.DeveloperId != developer.DeveloperId)
            {
                return Unauthorized();
            }
            if (developer != null)
            {
                Project pr = new Project()
                {
                    Developer = developer,
                    DeveloperId = developer.DeveloperId,
                    StreetNum = project.StreetNum,
                    StreetName = project.StreetName,
                    City = project.City,
                    PostalCode = project.PostalCode,
                    ProjectStatus = project.ProjectStatus,
                    ProjectImage = project.ProjectImage,
                    ProjectName = project.ProjectName,//not null
                    Created = DateTime.Now,// not null
                    ExpectedCompletion = project.ExpectedCompletion
                };
                _context.Projects.Add(pr);
                _context.SaveChanges();
                return Ok(pr);
            }
            return null;
        }

        [HttpPut]
        public IActionResult UpdateListing([FromBody] ProjectVM pVM)
        {

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string userName = "";
            if (identity != null)
            {
                userName = GetUserName(identity);
            }
            var developer = _context.Developers.Where(d => d.Email == userName).FirstOrDefault();
            var project = _context.Projects.Where(p => p.ProjectId == pVM.ProjectId).FirstOrDefault();
            if (project.DeveloperId != developer.DeveloperId)
            {
                return Unauthorized();
            }
            if (project != null)
            {
                project.StreetName = pVM.StreetName;
                project.StreetNum = pVM.StreetNum;
                project.City = pVM.City;
                project.PostalCode = pVM.PostalCode;
                project.ProjectStatus = pVM.ProjectStatus;
                project.ProjectImage = pVM.ProjectImage;
                project.ProjectLink = pVM.ProjectLink;
                project.ExpectedCompletion = pVM.ExpectedCompletion;
                //  project.Created = pVM.Created; //only their for testing time sort
                _context.SaveChanges();
                return Ok(project);
            }
            return NotFound();

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult RemoveListing(long id)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string userName = "";
            if (identity != null)
            {
                userName = GetUserName(identity);
            }
            var developer = _context.Developers.Where(d => d.Email == userName).FirstOrDefault();
            var project = _context.Projects.Where(p => p.ProjectId == id).FirstOrDefault();
            if (project.DeveloperId != developer.DeveloperId)
            {
                return Unauthorized();
            }
            if (project != null)
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

        private String GetUserName(ClaimsIdentity identity)
        {
            return identity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;
        }
    }
}
