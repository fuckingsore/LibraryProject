using AutoMapper;
using BLL.DTOs;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services.Implementations
{
    public class UserService : IUserService
    {
        IUnitOfWork db { get; set; }
        public UserService(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }
        public void Add(UserDTO entity)
        {
            try
            {
                User userEntity = new User()
                {
                    UserId = entity.UserId,
                    Name = entity.Name,
                    Surname = entity.Surname,
                    Email = entity.Email
                };
                db.Users.Add(userEntity);
            }
            catch (Exception)
            {
                throw new Exception("Cannot Add User");
            }
        }

        public UserDTO Get(int id)
        {
            try
            {
                var entity = db.Users.Get(id);
                UserDTO userDTO = new UserDTO()
                {
                    UserId = (int)entity.UserId,
                    Name = entity.Name,
                    Surname = entity.Surname,
                    Email = entity.Email
                };
                return userDTO;
            }
            catch (Exception)
            {
                throw new Exception("Cannot Get User");
            }
        }

        public List<UserDTO> GetAll()
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
                return mapper.Map<IEnumerable<User>, List<UserDTO>>(db.Users.GetAll());
            }
            catch (Exception)
            {
                throw new Exception("Cannot GetAll Users");
            }
        }

        public UserDTO GetByEmail(string email)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
                return mapper.Map<User, UserDTO>(db.Users.GetAll().Where(x => x.Email == email).FirstOrDefault());
            }
            catch (Exception)
            {
                throw new Exception("Cannot GetByEmail");
            }
        }

        public void Remove(int id)
        {
            try
            {
                db.Users.Remove(id);
            }
            catch (Exception)
            {
                throw new Exception("Cannot Remove User");
            }
        }

        public void Update(UserDTO entity, int id)
        {
            try
            {
                User userEntity = new User()
                {
                    UserId = entity.UserId,
                    Name = entity.Name,
                    Surname = entity.Surname,
                    Email = entity.Email
                };
                db.Users.Update(userEntity, id);
            }
            catch (Exception)
            {
                throw new Exception("Cannot Update User");
            }
        }
    }
}
