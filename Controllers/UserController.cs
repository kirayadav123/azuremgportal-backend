using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ctrlspec.Models;
using ctrlspec.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ctrlspec.Controllers
{
    [Route("[controller]")]
     public class UserController : Controller
      {
    //     private readonly ILogger<UserController> _logger;

    //     public UserController(ILogger<UserController> logger)
    //     {
    //         _logger = logger;
    //     }

    //     public IActionResult Index()
    //     {
    //         return View();
    //     }

    //     [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    //     public IActionResult Error()
    //     {
    //         return View("Error!");
    //     }

     private readonly IAdmin _context;
        public UserController(IAdmin context)
        {
            _context = context;
        }

         [HttpGet]
        public async Task<ActionResult> GetAllApp()
        {
            var admins = await _context.GetAllApp();
            if (admins == null)
            {
                return NotFound();
            }
            return Ok(admins);
        }
       

        [HttpGet("{Id}")]
        public async Task<ActionResult<Application>> GetByIDApp(int Id)
        {
            var app = await _context.GetByIDApp(Id);
            if (app == null)
            {
                return NotFound();
            }
            return Ok(app);
        }
        
      
        

    }
}