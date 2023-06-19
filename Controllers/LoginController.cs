
using ctrlspec.DTO;
using ctrlspec.Models;
using ctrlspec.Repos;
using ctrlspec.Repository;
using ctrlspec.Repository.ILogin;
using Microsoft.AspNetCore.Mvc;

namespace ctrlspec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _Login;
        private readonly ITokenHandler handler;


        public LoginController(ILogin _Login, ITokenHandler handler)
        {
            
            this._Login = _Login;
            this.handler = handler;
        }
        [HttpPost]
        [Route("SignUp")]
        public async Task<ActionResult<LoginRepository>> SignUp(Login loginTable)

        {
             var add = await _Login.SignUp(loginTable);
             
            if(loginTable == null)
            {
                return Ok ("Bad request");
            }

            return Ok("Success");
        }
       
      /*  [HttpPost]
        [Route("LoginAsync")]
        public async Task<IActionResult> LoginAsync(LoginDTO LoginDTO)
        {
            try
            {
                if 
                (LoginDTO.EmailId == null && LoginDTO.Password == null )
                {
                    return NotFound("EmailId or password is null");
                
                }
                //we check if user is authenticated which is check the username and password is present 
                // in our database.
                var user = await _Login.Login(LoginDTO.EmailId, LoginDTO.Password);
                if (user != null)
                {
                    var token = handler.CreateTokenAsync(user);
                    return Ok(token);
                }
                
                
                  return BadRequest("Emailid or password is incorrect ");
          

            }
        
                    //generate jwt token
            
        
             catch (Exception e)
             {
                 return BadRequest("Error in Controller method LoginAsync"+ e);
             }
        
    }*/

 [HttpPost]
        [Route("LoginAsync")]
        public async Task<IActionResult> LoginAsync(LoginDTO LoginDTO)
        {
            try
            {
                if 
                (LoginDTO.EmailId == null && LoginDTO.Password == null && LoginDTO.Role == null)
                {
                    return NotFound("EmailId or password is null");
                
                }
                //we check if user is authenticated which is check the username and password is present 
                // in our database.
                var user = await _Login.Login(LoginDTO.EmailId, LoginDTO.Password,LoginDTO.Role);
                if (user != null)
                {
                    var token = handler.CreateTokenAsync(user);
                    return Ok(token);
                }
                
                return BadRequest("Emailid or password or Role is incorrect ");
          

            }
        
                    //generate jwt token
            
        
             catch (Exception e)
             {
                 return BadRequest("Error in Controller method LoginAsync"+ e);
             }
        
    }

    }

}


