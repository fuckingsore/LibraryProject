using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.Interfaces
{
    public interface IUserService :IService<UserDTO>
    {
        UserDTO GetByEmail(string email);
    }
}
