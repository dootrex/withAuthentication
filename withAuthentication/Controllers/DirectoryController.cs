using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using withAuthentication.Models;

namespace withAuthentication.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoryController : ControllerBase
    {
        private PThreeDbContext _context;
        public DirectoryController(PThreeDbContext context) { _context = context; }

        [HttpGet]
        [Route("realtors")]
        public IActionResult getAllReators()
        {
            var realtors = _context.Realtors;
            return Ok(realtors);
        }


        [HttpGet]
        [Route("developers")]
        public IActionResult getAllDevelopers()
        {
            var devlopers = _context.Developers;
            return Ok(devlopers);
        }


        [HttpGet]
        [Route("developers/{id}")]
        public IActionResult getDeveloperById(long id)
        {
            Developer developer = _context.Developers.Where(d => d.DeveloperId == id).FirstOrDefault();
            return Ok(developer);
        }/**/

        [HttpGet]
        [Route("realtors/{id}")]
        public IActionResult getRealtorById(long id)
        {
            Realtor realtor = _context.Realtors.Where(d => d.RealtorId == id).FirstOrDefault();
            List<RealtorLanguage> languages = _context.RealtorLanguages.Where(rl => rl.RealtorId == realtor.RealtorId).ToList();
            return Ok(realtor);
        }


        [HttpGet]
        [Route("developers/name/{query}")]
        public IActionResult getDeveloperByName(string query)
        {
            return Ok(_context.Developers.Where(d => d.DeveloperName.Contains(query)));
        }


        [HttpGet]
        [Route("realtors/name/{query}")]
        public IActionResult getRealtorByName(string query)
        {
            //Realtor realtor = _context.Realtors.Where(r => r.FirstName.Contains(query) || r.LastName.Contains(query)).FirstOrDefault();
            //return Ok(realtor);
            return Ok(_context.Realtors.Where(r =>
                (r.FirstName + r.LastName).Contains(query)));
        }
        [HttpGet]
        [Route("realtors/lang/{langID}")]
        public IActionResult getRealtorsByLanguage(long langID)
        {
            List<RealtorLanguage> realtorLanguages = _context.RealtorLanguages.Where(rl => rl.LanguageId == langID).ToList();
            List<Realtor> realtors = new List<Realtor>();
            foreach (var item in realtorLanguages)
            {
                Realtor realtor = _context.Realtors.Where(r => r.RealtorId == item.RealtorId).FirstOrDefault();
                List<RealtorLanguage> languages = _context.RealtorLanguages.Where(rl => rl.RealtorId == realtor.RealtorId).ToList();
                realtors.Add(realtor);
            }
            return Ok(realtors);
        }

        private String GetUserName(ClaimsIdentity identity)
        {
            return identity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;
        }
    }
}
