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
     [Route("api/[controller]")]
    [ApiController]

    public class ClientController : ControllerBase
    {
        // private readonly ILogger<ClientController> _logger;

        // public ClientController(ILogger<ClientController> logger)
        // {
        //     _logger = logger;
        // }

        // public IActionResult Index()
        // {
        //     return View();
        // }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }

       private readonly IClient _context;
        public ClientController(IClient context)
        {
            _context = context;
        }
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

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var admins = await _context.GetAll();
            if (admins == null)
            {
                return NotFound();
            }
            return Ok(admins);
        }
       

        [HttpGet("{Id}")]
        public async Task<ActionResult<Application>> GetByID(int Id)
        {
            var app = await _context.GetByID(Id);
            if (app == null)
            {
                return NotFound();
            }
            return Ok(app);
        }
        [HttpPost]
        public async Task<ActionResult<Application>> Add(Application application)
        {


            var add = await _context.Add(application);
           
            if(application == null)
            {
                return BadRequest();
            }
            return Ok(add);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult> Update(int Id, Application application)
        {
            var app = await _context.Update(Id, application);
            return CreatedAtAction(nameof(GetByID), new { id = application.C_Id }, app);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            await _context.Delete(Id);
            return Ok();
        }

    }
}