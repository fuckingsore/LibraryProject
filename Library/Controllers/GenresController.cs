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
    public class GenresController : ControllerBase
    {
        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<GenreDTO, GenreViewModel>()).CreateMapper();
        IGenreService genreService;
        public GenresController(IGenreService service)
        {
            genreService = service;
        }
        // GET: api/<GenresController>
        [HttpGet]
        public IEnumerable<GenreViewModel> Get()
        {
            return mapper.Map<IEnumerable<GenreDTO>, List<GenreViewModel>>(genreService.GetAll());
        }

        // GET api/<GenresController>/5
        [HttpGet("{id}")]
        public GenreViewModel Get(int id)
        {
            return mapper.Map<GenreDTO, GenreViewModel>(genreService.Get(id));
        }

        // POST api/<GenresController>
        [HttpPost]
        public void Post([FromBody] GenreViewModel value)
        {
            GenreDTO genre = new GenreDTO()
            {
                GenreId = value.GenreId,
                GenreName = value.GenreName
            };
            genreService.Add(genre);
        }

        // PUT api/<GenresController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] GenreViewModel value)
        {
            GenreDTO genre = new GenreDTO()
            {
                GenreId = value.GenreId,
                GenreName = value.GenreName
            };
            genreService.Update(genre, id);
        }

        // DELETE api/<GenresController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            genreService.Remove(id);
        }
    }
}
