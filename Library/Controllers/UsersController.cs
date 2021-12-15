using AutoMapper;
using BLL.DTOs;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
        IUserService userService;
        public UsersController(IUserService service)
        {
            userService = service;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<UserViewModel> Get()
        {
            return mapper.Map<IEnumerable<UserDTO>, List<UserViewModel>>(userService.GetAll());
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public UserViewModel Get(int id)
        {
            return mapper.Map<UserDTO, UserViewModel>(userService.Get(id));
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] UserViewModel value)
        {
            UserDTO user = new UserDTO()
            {
                UserId = value.UserId,
                Name = value.Name,
                Surname = value.Surname,
                Email = value.Email
            };
            userService.Add(user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserViewModel value)
        {
            UserDTO user = new UserDTO()
            {
                UserId = value.UserId,
                Name = value.Name,
                Surname = value.Surname,
                Email = value.Email
            };
            userService.Update(user, id);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            userService.Remove(id);
        }
    }
}
