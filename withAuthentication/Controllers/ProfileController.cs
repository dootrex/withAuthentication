using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using withAuthentication.Models;
using withAuthentication.ViewModels;

namespace withAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private PThreeDbContext _context;
        public ProfileController(PThreeDbContext context) { _context = context; }

        [Authorize]
        [HttpGet]
        public IActionResult GetUserData()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string userName = "";
            string role = "";
            if (identity != null)
            {
                userName = GetUserName(identity);
                role = GetUserRole(identity);
            }
            else
            {
                return Unauthorized();
            }

            if (role == "Realtor")
            {
                Realtor realtor = _context.Realtors.Where(r => r.Email == userName).FirstOrDefault();
                var returnObject = new
                {
                    realtor,
                    role = "Realtor"
                };
                return Ok(returnObject);
            }
            if (role == "Developer")
            {
                var developer = _context.Developers.Where(r => r.Email == userName).FirstOrDefault();
                var returnObject = new
                {
                    developer,
                    role = "Developer"
                };
                return Ok(returnObject);
            }
            if (role == "PPOwner")
            {
                var ppowner = _context.PotentialBuyers.Where(r => r.Email == userName).FirstOrDefault();
                var returnObject = new
                {
                    ppowner,
                    role = "PPOwner"
                };
                return Ok(returnObject);
            }
            return Ok("failed");

        }

        [HttpGet]
        [Route("developer")]
        public IActionResult GetDeveloperDetails()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string userName = "";
            if (identity != null)
            {
                userName = GetUserName(identity);
            }
            var developer = _context.Developers.Where(d => d.Email == userName); ;
            return Ok(developer);
        }

        [Authorize(Roles = "Developer")]
        [HttpPut]
        [Route("developer")]
        public IActionResult UpdateDeveloperDetails([FromBody] AdrianDeveloperVM developer)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string userName = "";
            if (identity != null)
            {
                userName = GetUserName(identity);
            }
            var item = _context.Developers.Where(d => d.Email == userName).FirstOrDefault();

            if (item == null)
            {
                return NotFound();
            }
            else if (ModelState.IsValid)
            {
                item.DeveloperName = developer.DeveloperName;
                item.PhoneNumber = developer.PhoneNumber;
                item.Website = developer.Website;
                item.Logo = developer.Logo;
                _context.SaveChanges();
            }
            return new ObjectResult(developer);
        }

        [Authorize(Roles = "Realtor")]
        [HttpGet]
        [Route("realtor")]
        public IActionResult GetRealtorDetails()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string userName = "";
            if (identity != null)
            {
                userName = GetUserName(identity);
            }
            Realtor realtor = _context.Realtors.Where(r => r.Email == userName).FirstOrDefault();
            //dont delete the next line even if I am not returning it
            List<RealtorLanguage> languages = _context.RealtorLanguages.Where(rl => rl.RealtorId == realtor.RealtorId).ToList();
            var returnObject = new
            {
                realtor
            };

            return Ok(returnObject);
        }
        [Authorize(Roles = "Realtor")]
        [HttpPut]
        [Route("realtor")]
        public IActionResult UpdateRealtorDetails([FromBody] AdrianRealtorVM realtor)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string userName = "";
            if (identity != null)
            {
                userName = GetUserName(identity);
            }
            Realtor item = _context.Realtors.Where(r => r.Email == userName).FirstOrDefault();

            if (item == null)
            {
                return NotFound();
            }
            else if (ModelState.IsValid)
            {
                //get the languages 
                List<Language> languages = new List<Language>();
                foreach (var key in realtor.languageKeys)
                {
                    Language language = _context.Languages.Where(l => l.LanguageId == key).FirstOrDefault();
                    var check = _context.RealtorLanguages.Where(rl => rl.LanguageId == language.LanguageId && rl.RealtorId == item.RealtorId).FirstOrDefault();
                    if (check == null)
                    {
                        RealtorLanguage rl = new RealtorLanguage()
                        {
                            Language = language,
                            Realtor = item
                        };
                        _context.RealtorLanguages.Add(rl);
                    }

                }


                item.FirstName = realtor.FirstName;
                item.LastName = realtor.LastName;
                item.CompanyName = realtor.CompanyName;
                item.PhoneNumber = realtor.PhoneNumber;
                item.ProfilePic = realtor.ProfilePic;
                item.BioText = realtor.BioText;
                item.Website = realtor.Website;
                item.LinkedIn = realtor.LinkedIn;
                item.Twitter = realtor.Twitter;
                item.Youtube = realtor.Youtube;
                item.Facebook = realtor.Facebook;
                item.Instagram = realtor.Instagram;

                _context.SaveChanges();
            }
            return new ObjectResult(realtor);
        }


        [Authorize(Roles = "PPOwner")]
        [HttpGet]
        [Route("ppowner")]
        public IActionResult GetPPBuyerDetails()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string userName = "";
            if (identity != null)
            {
                userName = GetUserName(identity);
            }
            var ppBuyer = _context.PotentialBuyers.Where(p => p.Email == userName);
            return Ok(ppBuyer);
        }


        [Authorize(Roles = "PPOwner")]
        [HttpPut]
        [Route("ppowner")]
        public IActionResult UpdatePPBuyerDetails([FromBody] AdrianPotentialBuyerVM potentialBuyer)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string userName = "";
            if (identity != null)
            {
                userName = GetUserName(identity);
            }
            var item = _context.PotentialBuyers.Where(p => p.Email == userName).FirstOrDefault();

            if (item == null)
            {
                return NotFound();
            }
            else if (ModelState.IsValid)
            {
                item.FirstName = potentialBuyer.FirstName;
                item.LastName = potentialBuyer.LastName;
                item.PhoneNumber = potentialBuyer.PhoneNumber;

                _context.SaveChanges();
            }
            return new ObjectResult(potentialBuyer);
        }



        private String GetUserName(ClaimsIdentity identity)
        {
            return identity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;
        }

        private String GetUserRole(ClaimsIdentity identity)
        {
            return identity.FindFirst("http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Value;
        }
    }
}

