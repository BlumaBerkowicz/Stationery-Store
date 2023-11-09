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
                return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
            }
            catch (Exception e)
                { throw (e); }


        }
        // PUT api/<RegisterAndLogin>/5
        [HttpPut("{id}")]
        public async Task<User> Put(int id, [FromBody] User userToUpdate)
        {
            return await userServices.UpdateUser(id, userToUpdate);
        }

        [HttpPost("check")]
        public async Task<int> Check([FromBody] string password)
        {
            if (password != "")
            {
                return await userServices.check(password);
            }
            return -1;


        }
        // DELETE api/<RegisterAndLogin>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
