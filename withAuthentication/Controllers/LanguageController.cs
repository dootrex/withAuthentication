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
    public class LanguageController : ControllerBase
    {
        private PThreeDbContext _context;
        public LanguageController(PThreeDbContext context) { _context = context; }

        [HttpGet]
        public IActionResult GetAllLanguages()
        {
            return Ok(_context.Languages);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetLanguage(int id)
        {
            return Ok(_context.Languages.Where(l => l.LanguageId == id).FirstOrDefault());
        }
    }
}
