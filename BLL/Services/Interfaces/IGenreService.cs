using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.Interfaces
{
    public interface IGenreService :IService<GenreDTO>
    {
        List<GenreDTO> GetOrderByName(); 
    }
}
