﻿using Repository;
using Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Dto;
using AutoMapper;
using Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ex02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
      private readonly IUserService  userServices;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UserController(IUserService userServices, IMapper mapper,ILogger<UserController> logger)
        {
            this.userServices = userServices;
            _mapper = mapper;
            _logger = logger;
        }

        [Route("login")]
        // GET api/<RegisterAndLogin>/5
        [HttpPost]
        public async Task< ActionResult<User>> Get([FromBody] UserLoginDto userLOginDto)
        {
            var userName = userLOginDto.Email;
            var password = userLOginDto.Password;
            User user = await userServices.GetUser(userLOginDto);
            if (user == null)
                return NoContent();
            return Ok(user);

        }

        // POST api/<RegisterAndLogin>
        [HttpPost]
        public async Task<CreatedAtActionResult> Post([FromBody] UserDto userDto)
        {
     
            _logger.LogInformation($"Login attempted with userName {userDto.Email} and password {userDto.Password}");
             User newUser = _mapper.Map<UserDto, User>(userDto);
             await userServices.Post(newUser);
             return CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUser);

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
