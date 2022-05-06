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

            return Ok(_context.Realtors.Select(r => new { firstName = r.FirstName, lastName = r.LastName, realtorID = r.RealtorId, profilePic = r.ProfilePic }));
        }


        [HttpGet]
        [Route("developers")]
        public IActionResult getAllDevelopers()
        {
            return Ok(_context.Developers.Select(d => new { developerID = d.DeveloperId, developerName = d.DeveloperName, logo = d.Logo }));
        }


        [HttpGet]
        [Route("developers/{id}")]
        public IActionResult getDeveloperById(long id)
        {
            var developer = _context.Developers.Where(d => d.DeveloperId == id).Select(d => new { developer = d, reviews = d.DeveloperReviews.Select(dr => new { reviewID = dr.ReviewId, starRating = dr.StarRating, comment = dr.Comment, potentialBuyer = dr.PotentialBuyer }).ToList() }).FirstOrDefault();
            return Ok(developer);
        }

        [HttpGet]
        [Route("realtors/{id}")]
        public IActionResult getRealtorById(long id)
        {
            var realtor = _context.Realtors.Where(r => r.RealtorId == id).Select(r => new { realtor = r, languages = r.RealtorLanguages.Select(rl => new { languageId = rl.LanguageId, languageName = rl.Language.LanguageName }).ToList(), reviews = r.RealtorReviews.Select(rr => new { reviewID = rr.ReviewId, starRating = rr.StarRating, comment = rr.Comment, potentialBuyer = rr.PotentialBuyer }).ToList() }).FirstOrDefault(); ;

            return Ok(realtor);
        }


        [HttpGet]
        [Route("developers/name/{query}")]
        public IActionResult getDeveloperByName(string query)
        {
            return Ok(_context.Developers.Where(d => d.DeveloperName.Contains(query)).Select(d => new { developerID = d.DeveloperId, developerName = d.DeveloperName, logo = d.Logo }));
        }


        [HttpGet]
        [Route("realtors/name/{query}")]
        public IActionResult getRealtorByName(string query)
        {

            return Ok(_context.Realtors.Where(r => (r.FirstName + r.LastName).Contains(query)).Select(r => new { firstName = r.FirstName, lastName = r.LastName, realtorID = r.RealtorId, profilePic = r.ProfilePic }));
        }
        [HttpGet]
        [Route("realtors/lang/{langID}")]
        public IActionResult getRealtorsByLanguage(long langID)
        {
            var realtors = _context.RealtorLanguages.Where(rl => rl.LanguageId == langID).Select(rl => new { firstName = rl.Realtor.FirstName, lastName = rl.Realtor.LastName, profilePic = rl.Realtor.ProfilePic, realtorID = rl.Realtor.RealtorId });
            return Ok(realtors);
        }
    }
}
