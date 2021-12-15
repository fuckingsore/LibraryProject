using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.Interfaces
{
    public interface IAuthorService:IService<AuthorDTO>
    {
        List<AuthorDTO> GetSortedBySurname(string authorSurname);
    }
}
