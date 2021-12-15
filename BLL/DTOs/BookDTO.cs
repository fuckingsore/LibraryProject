using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class BookDTO
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
    }
}
