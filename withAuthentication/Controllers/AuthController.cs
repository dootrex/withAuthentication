using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using withAuthentication.Models;
using withAuthentication.ViewModels;

namespace withAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;   // allow us to read appsettings.json
        private IServiceProvider _serviceProvider;  // for login

        // Identity
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager; // handling user roles during the registration
        private PThreeDbContext _context;


        //constructor with injection
        public AuthController(IConfiguration config,
            IServiceProvider serviceProvider,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            PThreeDbContext context)
        {
            _config = config;
            _serviceProvider = serviceProvider; // for login
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager; // added for roles
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = registerVM.Email, Email = registerVM.Email };
                var result = await _userManager.CreateAsync(user, registerVM.Password);

                // Please comment out the following 4 lines of code after registering one user. As they are used to create roles.
                /*     _context.Roles.Add(new IdentityRole { Name = "PPOwner", Id = "PPOwner", NormalizedName = "PPOWNER" });
                     _context.Roles.Add(new IdentityRole { Name = "Developer", Id = "Developer", NormalizedName = "DEVELOPER" });
                     _context.Roles.Add(new IdentityRole { Name = "Realtor", Id = "Realtor", NormalizedName = "REALTOR" });
                     _context.SaveChanges();

                     string[] langs = new string[]{
                                                 "Mandarin Chinese",
                                                 "Spanish",
                                                 "English",
                                                 "Hindi/Urdu",
                                                 "Arabic",
                                                 "Bengali",
                                                 "Portuguese",
                                                 "Russian",
                                                 "Japanese",
                                                 "German",
                                                 "Javanese",
                                                 "Punjabi",
                                                 "Wu",
                                                 "French",
                                                 "Telugu",
                                                 "Vietnamese",
                                                 "Marathi",
                                                 "Korean",
                                                 "Tamil",
                                                 "Italian",
                                                 "Turkish",
                                                 "Cantonese/Yue"
                                                };
                     foreach (var lang in langs)
                     {
                         Language language = new Language()
                         {
                             LanguageName = lang
                         };
                         _context.Languages.Add(language);
                         _context.SaveChanges();
                     }*/
                if (result.Succeeded)
                {

                    //add user to their table
                    if (registerVM.Role == "Realtor")
                    {
                        Realtor realtor = new Realtor()
                        {
                            Email = registerVM.Email
                        };
                        _context.Realtors.Add(realtor);
                        _context.SaveChanges();
                    }
                    if (registerVM.Role == "Developer")
                    {
                        Developer developer = new Developer()
                        {
                            Email = registerVM.Email
                        };
                        _context.Developers.Add(developer);
                        _context.SaveChanges();
                    }
                    if (registerVM.Role == "PPOwner")
                    {
                        PotentialBuyer potentialBuyer = new PotentialBuyer()
                        {
                            Email = registerVM.Email
                        };
                        _context.PotentialBuyers.Add(potentialBuyer);
                        _context.SaveChanges();
                    }


                    await _userManager.AddToRoleAsync(user, registerVM.Role);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    return new ObjectResult(new { result = code, StatusCode = "Result is valid. New user has been created" });
                }
                return new ObjectResult(new { tokenString = "", StatusCode = "Model (register) is not valid." });
            }
            else
            {
                return BadRequest();
            }

        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(loginVM.Email.ToUpper(), loginVM.Password, false, lockoutOnFailure: true);
                Response.Cookies.Delete(".AspNetCore.Identity.Application");
                if (result.Succeeded)
                {
                    //try the following code by using the above dependancy injection
                    var UserManager = _serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
                    var user = await UserManager.FindByEmailAsync(loginVM.Email);
                    if (user != null)
                    {
                        var tokenString = GenerateJWT(user);
                        var jsonOK = new { tokenString = tokenString, StatusCode = "OK" };

                        return new ObjectResult(jsonOK);
                    }
                    return new ObjectResult(new { tokenString = "", StatusCode = "Result is not valid." });
                }
                return new ObjectResult(new { tokenString = "", StatusCode = "Model is not valid." });
            }
            else
            {
                return BadRequest();
            }
        }

        // Adding user roles from identity to list of claims
        List<Claim> AddUserRoleClaims(List<Claim> claims, string userId)
        {
            // Get current user's roles. 
            var userRoleList = _context.UserRoles.Where(ur => ur.UserId == userId);
            var roleList = from ur in userRoleList
                           from r in _context.Roles
                           where r.Id == ur.RoleId
                           select new { r.Name };

            // Add each of the user's roles to the claims list.
            foreach (var roleItem in roleList)
            {
                claims.Add(new Claim(ClaimTypes.Role, roleItem.Name));
            }
            return claims;
        }


        private string GenerateJWT(IdentityUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            // Define claims - storing data about user, in JWT it's a Payload section
            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
               // new Claim(ClaimTypes.Role, user.UserName),
                // new Claim("role", "user") // another way how to define custom things
            };
            // adding user roles to the claims
            claims = AddUserRoleClaims(claims, user.Id);

            // Define token
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
