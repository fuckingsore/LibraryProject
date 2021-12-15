using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services.Interfaces;
using PL.Models;
using AutoMapper;
using BLL.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<AuthorDTO, AuthorViewModel>()).CreateMapper();
        IAuthorService authorService;
        public AuthorsController(IAuthorService service)
        {
            authorService = service;
        }
        // GET: api/<AuthorsController>
        [HttpGet]
        public IEnumerable<AuthorViewModel> Get()
        {
            return mapper.Map<IEnumerable<AuthorDTO>, List<AuthorViewModel>>(authorService.GetAll());
        }

        // GET api/<AuthorsController>/5
        [HttpGet("{id}")]
        public AuthorViewModel Get(int id)
        {
            return mapper.Map<AuthorDTO, AuthorViewModel>(authorService.Get(id));
        }

        // POST api/<AuthorsController>
        [HttpPost]
        public void Post([FromBody] AuthorViewModel value)
        {
            AuthorDTO author = new AuthorDTO()
            {
                AuthorId = value.AuthorId,
                Name = value.Name,
                Surname = value.Surname
            };
            authorService.Add(author);
        }

        // PUT api/<AuthorsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] AuthorViewModel value)
        {
            AuthorDTO author = new AuthorDTO()
            {
                AuthorId = value.AuthorId,
                Name = value.Name,
                Surname = value.Surname
            };
            authorService.Update(author, id);
        }

        // DELETE api/<AuthorsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            authorService.Remove(id);
        }
    }
}
