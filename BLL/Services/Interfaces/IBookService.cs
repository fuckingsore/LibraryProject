using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.Interfaces
{
    public interface IBookService :IService<BookDTO>
    {
        List<BookDTO> GetByName(string bookName);
        List<BookDTO> GetByAuthor(string authorName);
        List<BookDTO> GetByGenre(string genreName);
        void AddToGenre(int genreId, int bookId);
    }
}
