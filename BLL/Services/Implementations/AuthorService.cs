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
    public class AuthorService : IAuthorService
    {
        IUnitOfWork db { get; set; }
        public AuthorService(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }
        public void Add(AuthorDTO entity)
        {

                Author authorEntity = new Author()
                {
                    AuthorId = entity.AuthorId, 
                    Name = entity.Name,
                    Surname = entity.Surname
                };
                db.Authors.Add(authorEntity);

        }

        public AuthorDTO Get(int id)
        {
            try
            {
                var entity = db.Authors.Get(id);
                AuthorDTO authorDTO = new AuthorDTO()
                {
                    AuthorId = (int)entity.AuthorId,
                    Name = entity.Name,
                    Surname = entity.Surname
                };
                return authorDTO;
            }
            catch(Exception)
            {
                throw new Exception("Cannot Get Author");
            }
        }

        public List<AuthorDTO> GetAll()
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Author, AuthorDTO>()).CreateMapper();
                return mapper.Map<IEnumerable<Author>, List<AuthorDTO>>(db.Authors.GetAll());
            }
            catch(Exception)
            {
                throw new Exception("Cannot GetAll Authors");
            }
        }

        public List<AuthorDTO> GetSortedBySurname(string authorSurname)
        {
            try
            {
                PropertyInfo propertyInfo = typeof(Author).GetProperty(authorSurname);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Author, AuthorDTO>()).CreateMapper();
                return mapper.Map<IEnumerable<Author>, List<AuthorDTO>>(db.Authors.GetAll().OrderBy(x => propertyInfo.GetValue(x, null)).ToList());
            }
            catch(Exception)
            {
                throw new Exception("Cannot GetSortedBySurname Authors");
            }
        }

        public void Remove(int id)
        {
                db.Authors.Remove(id);
        }

        public void Update(AuthorDTO entity, int id)
        {
            try
            {
                Author authorEntity = new Author()
                {
                    AuthorId = entity.AuthorId,
                    Name = entity.Name,
                    Surname = entity.Surname
                };
                db.Authors.Update(authorEntity, id);
            }
            catch(Exception)
            {
                throw new Exception("Cannot Update Author");
            }
        }
    }
}
