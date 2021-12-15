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
    public class GenreService : IGenreService
    {
        IUnitOfWork db { get; set; }
        public GenreService(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }
        public void Add(GenreDTO entity)
        {
            try
            {
                Genre genreEntity = new Genre()
                {
                    GenreId = entity.GenreId,
                    GenreName = entity.GenreName
                };
                db.Genres.Add(genreEntity);
            }
            catch (Exception)
            {
                throw new Exception("Cannot Add Genre");
            }
        }

        public GenreDTO Get(int id)
        {
            try
            {
                var entity = db.Genres.Get(id);
                GenreDTO genreDTO = new GenreDTO()
                {
                    GenreId = (int)entity.GenreId,
                    GenreName = entity.GenreName
                };
                return genreDTO;
            }
            catch (Exception)
            {
                throw new Exception("Cannot Get Genre");
            }
        }

        public List<GenreDTO> GetAll()
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Genre, GenreDTO>()).CreateMapper();
                return mapper.Map<IEnumerable<Genre>, List<GenreDTO>>(db.Genres.GetAll());
            }
            catch (Exception)
            {
                throw new Exception("Cannot GetAll Genres");
            }
        }

        public List<GenreDTO> GetOrderByName()
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Genre, GenreDTO>()).CreateMapper();
                return mapper.Map<IEnumerable<Genre>, List<GenreDTO>>(db.Genres.GetAll().OrderBy(x => x.GenreName).ToList());
            }
            catch (Exception)
            {
                throw new Exception("Cannot GetOrderByName");
            }
        }

        public void Remove(int id)
        {
            try
            {
                db.Genres.Remove(id);
            }
            catch (Exception)
            {
                throw new Exception("Cannot Remove Genre");
            }
        }

        public void Update(GenreDTO entity, int id)
        {
            try
            {
                Genre genreEntity = new Genre()
                {
                    GenreId = entity.GenreId,
                    GenreName = entity.GenreName
                };
                db.Genres.Update(genreEntity, id);
            }
            catch (Exception)
            {
                throw new Exception("Cannot Update Genre");
            }
        }
    }
}
