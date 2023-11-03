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
        public ActionResult<User> Get([FromQuery]string userName="", [FromQuery] string password="")
        {
            User user = userServices.GetUserByUserNameAndPassword(userName, password);
            if (user == null)
                return NoContent();
            return Ok(user);
          

        }

        // POST api/<RegisterAndLogin>
        [HttpPost]
        public CreatedAtActionResult Post([FromBody] User user)
        {
                User newUser = userServices.Post(user);
                return CreatedAtAction(nameof(Get), new { id = user.userId }, user);
        }
        // PUT api/<RegisterAndLogin>/5
        [HttpPut("{id}")]
        public User Put(int id, [FromBody] User userToUpdate)
        {
            return userServices.UpdateUser(id, userToUpdate);
        }
        [HttpPost("check")]
        public int Check([FromBody] string password)
        {
            if (password != "")
            {
                var result = Zxcvbn.Core.EvaluatePassword(password);
                return result.Score;
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
