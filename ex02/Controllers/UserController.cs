using Entities;
using Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ex02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
      private readonly IUserService  userServices;

        public UserController(IUserService userServices)
        {
            this.userServices = userServices;
        }


        // GET api/<RegisterAndLogin>/5
        [HttpGet]
        public async Task< ActionResult<User>> Get([FromQuery]string userName="", [FromQuery] string password="")
        {
            User user = await userServices.GetUserByUserNameAndPassword(userName, password);
            if (user == null)
                return NoContent();
            return Ok(user);

        }

        // POST api/<RegisterAndLogin>
        [HttpPost]
        public async Task< CreatedAtActionResult> Post([FromBody] User user)
        {
            try
            {            
                User newUser = await userServices.Post(user);
                //Check if newUser== null return BadRequest()
                //CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUser); - newUser instead of the old user!
                return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);

            }
            catch (Exception e)
            //Throwing an exception- cause a 500  error code (internal server error). 
            { throw (e); }


        }
        // PUT api/<RegisterAndLogin>/5
        [HttpPut("{id}")]
        //Function should return Task<ActionResult<User>
        //Return the updatedUser 
        //Check : if updatrdUser==null return BadRequesst() (or NoContent())  else OK(user) 
        public async Task<User> Put(int id, [FromBody] User userToUpdate)
        {
            return await userServices.UpdateUser(id, userToUpdate);
        }

        [HttpPost("check")]
        //meaningfull function name: CheckPasswordStrength
        public async Task<int> Check([FromBody] string password)
        {
            if (password != "")
            {
                return await userServices.check(password);
            }
            return -1;


        }
        //Clean code -Remove unnecessary lines of code.
        // DELETE api/<RegisterAndLogin>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
