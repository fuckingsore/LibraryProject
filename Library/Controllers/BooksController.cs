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
    public class BooksController : ControllerBase
    {
        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, BookViewModel>()).CreateMapper();
        IBookService bookService;
        public BooksController(IBookService service)
        {
            bookService = service;
        }
        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<BookViewModel> Get()
        {
            return mapper.Map<IEnumerable<BookDTO>, List<BookViewModel>>(bookService.GetAll());
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public BookViewModel Get(int id)
        {
            return mapper.Map<BookDTO, BookViewModel>(bookService.Get(id));
        }

        // POST api/<BooksController>
        [HttpPost]
        public void Post([FromBody] BookViewModel value)
        {
            BookDTO book = new BookDTO()
            {
                BookId = value.BookId,
                Name = value.Name,
                AuthorId = value.AuthorId,
                GenreId = value.GenreId
            };
            bookService.Add(book);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] BookViewModel value)
        {
            BookDTO book = new BookDTO()
            {
                BookId = value.BookId,
                Name = value.Name,
                AuthorId = value.AuthorId,
                GenreId = value.GenreId
            };
            bookService.Update(book,id);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bookService.Remove(id);
        }
    }
}
