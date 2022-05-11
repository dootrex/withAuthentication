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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private PThreeDbContext _context;
        public ReviewController(PThreeDbContext context) { _context = context; }


        [HttpGet]
        [Route("developer/{id}")]
        public IActionResult GetReviewsByDeveloperId(int id)
        {
            var developerReview = _context.DeveloperReviews.Where(r => r.DeveloperId == id).Select(r => new { review = r, potentialBuyer = r.PotentialBuyer });
            if (developerReview == null)
            {
                return NotFound();
            }
            return new ObjectResult(developerReview);
        }

        [HttpGet]
        [Route("realtor/{id}")]
        public IActionResult GetReviewsByRealtorId(int id)
        {
            var realtorReview = _context.RealtorReviews.Where(r => r.RealtorId == id).Select(r => new { review = r, potentialBuyer = r.PotentialBuyer });

            if (realtorReview == null)
            {
                return NotFound();
            }
            return new ObjectResult(realtorReview);
        }
        [Authorize(Roles = "PPOwner")]
        [HttpPost]
        [Route("developer/{id}")]
        public IActionResult AddReviewByDeveloperID(int id, [FromBody] DeveloperReview developerReview)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string userName = "";
            if (identity != null)
            {
                userName = GetUserName(identity);
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
            _context.SaveChanges();

            Developer developer = _context.Developers.Where(d => d.DeveloperId == id).FirstOrDefault();
            if (developer.AvgStarRating != null)
            {
                developer.AvgStarRating = (decimal?)_context.DeveloperReviews.Where(r => r.DeveloperId == id).Average(r => r.StarRating);
            }
            else
            {
                developer.AvgStarRating = developerReview.StarRating;
            }
            _context.SaveChanges();

            return Ok();
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "PPOwner")]
        [HttpPost]
        [Route("realtor/{id}")]
        public IActionResult AddReviewByRealtorID(int id, [FromBody] RealtorReview realtorReview)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string userName = "";
            if (identity != null)
            {
                userName = GetUserName(identity);
            }
            var userId = _context.PotentialBuyers.Where(d => d.Email == userName).FirstOrDefault();
            var review = new RealtorReview()
            {
                RealtorId = id,
                PotentialBuyerId = userId.PotentialBuyerId,
                Comment = realtorReview.Comment,
                StarRating = realtorReview.StarRating,
            };
            _context.RealtorReviews.Add(review);
            _context.SaveChanges();

            // Update Average Star Rating
            Realtor realtor = _context.Realtors.Where(r => r.RealtorId == id).FirstOrDefault();
            if (realtor.AvgStarRating != null)
            {
                realtor.AvgStarRating = (decimal?)_context.RealtorReviews.Where(r => r.RealtorId == id).Average(r => r.StarRating);
            }
            else
            {
                realtor.AvgStarRating = realtorReview.StarRating;
            }
            _context.SaveChanges();

            return Ok();
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "PPOwner")]
        [HttpDelete("developer/{id}")]
        public IActionResult RemoveDeveloperReviewByID(int id)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string userName = "";
            if (identity != null)
            {
                userName = GetUserName(identity);
            }
            var ppOwner = _context.PotentialBuyers.Where(pp => pp.Email == userName).FirstOrDefault();
            var developerReview = _context.DeveloperReviews.Where(d => d.ReviewId == id).FirstOrDefault();
            /*  if (ppOwner.PotentialBuyerId != developerReview.PotentialBuyerId)
              {
                  return Unauthorized();
              }*/
            if (developerReview == null)
            {
                return NotFound();
            }
            try
            {
                _context.DeveloperReviews.Remove(developerReview);
                _context.SaveChanges();

                // Update Average Star Rating
                Developer developer = _context.Developers.Where(r => r.DeveloperId == developerReview.DeveloperId).FirstOrDefault();
                var ratings = _context.DeveloperReviews.Where(r => r.DeveloperId == developerReview.DeveloperId).ToList();
                if (ratings.Count > 0)
                {
                    developer.AvgStarRating = (decimal?)ratings.Average(r => r.StarRating);
                }
                else
                {
                    developer.AvgStarRating = null;
                }
                _context.SaveChanges();

                return new ObjectResult(developerReview);
            }
            catch
            {
                return Conflict();
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "PPOwner")]
        [HttpDelete("realtor/{id}")]
        public IActionResult RemoveRealtorReviewByID(int id)
        {

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string userName = "";
            if (identity != null)
            {
                userName = GetUserName(identity);
            }
            var ppOwner = _context.PotentialBuyers.Where(pp => pp.Email == userName).FirstOrDefault();
            var realtorReview = _context.RealtorReviews.Where(d => d.ReviewId == id).FirstOrDefault();

            if (realtorReview == null)
            {
                return NotFound();
            }
            try
            {
                _context.RealtorReviews.Remove(realtorReview);
                _context.SaveChanges();

                // Update Average Star Rating
                Realtor realtor = _context.Realtors.Where(r => r.RealtorId == realtorReview.RealtorId).FirstOrDefault();
                var ratings = _context.RealtorReviews.Where(r => r.RealtorId == realtorReview.RealtorId).ToList();
                if (ratings.Count > 0)
                {
                    realtor.AvgStarRating = (decimal?)ratings.Average(r => r.StarRating);
                }
                else
                {
                    realtor.AvgStarRating = null;
                }
                _context.SaveChanges();

                return new ObjectResult(realtorReview);
            }
            catch
            {
                return Conflict();
            }
        }
        private String GetUserName(ClaimsIdentity identity)
        {
            return identity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;
        }
    }
}