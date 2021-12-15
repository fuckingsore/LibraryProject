using AutoMapper;
using BLL.DTOs;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BLL.Services.Implementations
{
    public class BookService : IBookService
    {
        IUnitOfWork db { get; set; }
        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>()).CreateMapper();
        public BookService(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }
        public void Add(BookDTO entity)
        {
            try
            {
                Book bookEntity = new Book()
                {
                    BookId = entity.BookId,
                    Name = entity.Name,
                    AuthorId = entity.AuthorId,
                    GenreId = entity.GenreId
                };
                db.Books.Add(bookEntity);
            }
            catch (Exception)
            {
                throw new Exception("Cannot Add Book");
            }
        }

        public void AddToGenre(int genreId, int bookId)
        {
            try
            {
                var book = db.Books.Get(bookId);
                if (book.GenreId != null) throw new Exception("Genre has already exist");
                book.GenreId = genreId;
                db.Books.Update(book, bookId);
            }
            catch(Exception)
            {
                throw new Exception("Cannot AddToGenre");
            }
        }

        public BookDTO Get(int id)
        {
            try
            {
                var entity = db.Books.Get(id);
                BookDTO bookDTO = new BookDTO()
                {
                    BookId = (int)entity.BookId,
                    Name = entity.Name,
                    AuthorId = (int)entity.AuthorId,
                    GenreId = (int)entity.GenreId
                };
                return bookDTO;
            }
            catch (Exception)
            {
                throw new Exception("Cannot Get Book");
            }
        }

        public List<BookDTO> GetAll()
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>()).CreateMapper();
                return mapper.Map<IEnumerable<Book>, List<BookDTO>>(db.Books.GetAll());
            }
            catch (Exception)
            {
                throw new Exception("Cannot GetAll Books");
            }
        }

        public List<BookDTO> GetByAuthor(string authorName)
        {
            try
            {
                
                return mapper.Map<IEnumerable<Book>, List<BookDTO>>(db.Books.GetAll().Where(x => x.Author.Name==authorName).ToList());
            }
            catch (Exception)
            {
                throw new Exception("Cannot GetByAuthor");
            }
        }

        public List<BookDTO> GetByGenre(string genreName)
        {
            try
            {
                
                return mapper.Map<IEnumerable<Book>, List<BookDTO>>(db.Books.GetAll().Where(x => x.Genre.GenreName==genreName).ToList());
            }
            catch (Exception)
            {
                throw new Exception("Cannot GetByGenre");
            }
        }

        public List<BookDTO> GetByName(string bookName)
        {
            try
            {
                
                return mapper.Map<IEnumerable<Book>, List<BookDTO>>(db.Books.GetAll().Where(x => x.Name==bookName).ToList());
            }
            catch (Exception)
            {
                throw new Exception("Cannot GetByName");
            }
        }

        public void Remove(int id)
        {
            try
            {
                db.Books.Remove(id);
            }
            catch (Exception)
            {
                throw new Exception("Cannot Remove Book");
            }
        }

        public void Update(BookDTO entity, int id)
        {
            try
            {
                Book bookEntity = new Book()
                {
                    BookId = entity.BookId,
                    Name = entity.Name,
                    AuthorId = entity.AuthorId,
                    GenreId = entity.GenreId
                };
                db.Books.Update(bookEntity, id);
            }
            catch (Exception)
            {
                throw new Exception("Cannot Update Book");
            }
        }
    }
}
