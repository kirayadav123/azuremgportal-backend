using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ctrlspec.Models;
using ctrlspec.Repository;
using ctrlspec.Repository.ILogin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ctrlspec.Controllers
{
   /* [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }*/

   [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ILogin _login;
       
        public AdminController(ILogin login)
        {
            _login = login;
            
        }
        
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var admins = await _login.GetAll();
            if (admins == null)
            {
                return NotFound();
            }
            return Ok(admins);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Login>> GetByID(int Id)
        {
            var admins = await _login.GetByID(Id);
            if (admins == null)
            {
                return NotFound();
            }
            return Ok(admins);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            await _login.Delete(Id);
            return Ok();
        }


   //Application Crud
   
        // [HttpGet]
        // public async Task<ActionResult> GetAll()
        // {
        //     var app = await _context.GetAll();
        //     if (app == null)
        //     {
        //         return NotFound();
        //     }
        //     return Ok(app);
        // }

        // [HttpGet]
        // public async Task<ActionResult> GetAllApp()
        // {
        //     var admins = await _context.GetAllApp();
        //     if (admins == null)
        //     {
        //         return NotFound();
        //     }
        //     return Ok(admins);
        // }
       

        // [HttpGet("{Id}")]
        // public async Task<ActionResult<Application>> GetByIDApp(int Id)
        // {
        //     var app = await _context.GetByIDApp(Id);
        //     if (app == null)
        //     {
        //         return NotFound();
        //     }
        //     return Ok(app);
        // }
        
      
        // [HttpDelete("{Id}")]
        // public async Task<ActionResult> DeleteApp(int Id)
        // {
        //     await _context.DeleteApp(Id);
        //     return Ok();
        // }


    }

}