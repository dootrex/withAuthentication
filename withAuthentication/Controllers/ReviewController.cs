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

namespace withAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private PThreeDbContext _context;
        public ReviewController(PThreeDbContext context) { _context = context; }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        [Route("developer/{id}")]
        public IActionResult GetReviewByDeveloperId(int id)
        {
            var developerReview = _context.DeveloperReviews.Where(r => r.DeveloperId == id);
            return Ok(developerReview);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Realtor")]
        [HttpGet]
        [Route("realtor/{id}")]
        public IActionResult GetReviewByRealtorId(int id)
        {
            var realtorReview = _context.RealtorReviews.Where(r => r.RealtorId == id);
            if (realtorReview == null)
            {
                return NotFound();
            }
            return new ObjectResult(realtorReview);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "PPOwner")]
        [HttpPost]
        [Route("developer/{id}")]
        public IActionResult AddReviewByDeveloperID(int id, [FromBody] DeveloperReview developerReview)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string userName = "";
            if (identity != null)
            {
                userName = identity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;
            }
            var userId = _context.PotentialBuyers.Where(d => d.Email == userName).FirstOrDefault();
            var review = new DeveloperReview()
            {
                DeveloperId = id,
                PotentialBuyerId = userId.PotentialBuyerId,
                Comment = developerReview.Comment,
                StarRating = developerReview.StarRating,
            };
            _context.DeveloperReviews.Add(review);

            Developer developer = _context.Developers.Where(d => d.DeveloperId == id).FirstOrDefault();
            //Count number of reviews and then get avg



            if (developer.AvgStarRating != null)
            {
                developer.AvgStarRating = (developerReview.StarRating + developer.AvgStarRating / 2);
            }
            else
            {
                developer.AvgStarRating = developerReview.StarRating;
            }

            _context.SaveChanges();


            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult MyDelete(int id)
        {
            var developerReview = _context.DeveloperReviews.Where(d => d.ReviewId == id).FirstOrDefault();
            if (developerReview == null)
            {
                return NotFound();
            }
            try
            {
                _context.DeveloperReviews.Remove(developerReview);
                _context.SaveChanges();
                return new ObjectResult(developerReview);
            }
            catch
            {
                return Conflict();
            }

        }
    }
}