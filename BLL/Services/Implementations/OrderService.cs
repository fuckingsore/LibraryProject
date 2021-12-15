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
    public class OrderService : IOrderService
    {
        IUnitOfWork db { get; set; }
        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>()).CreateMapper();
        public OrderService(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }
        public void Add(OrderDTO entity)
        {
            try
            {

                Order orderEntity = new Order()
                {
                    OrderId = entity.OrderId,
                    UserId = entity.UserId,
                    BookId = entity.BookId
                };
                db.Orders.Add(orderEntity);
            }
            catch (Exception)
            {
                throw new Exception("Cannot Add Order");
            }
        }

        public OrderDTO Get(int id)
        {
            try
            {
                var entity = db.Orders.Get(id);
                
                OrderDTO orderDTO = new OrderDTO()
                {
                    OrderId = (int)entity.OrderId,
                    UserId = (int)entity.UserId,
                    BookId = (int)entity.BookId
                };
                return orderDTO;
            }
            catch (Exception)
            {
                throw new Exception("Cannot Get Order");
            }
        }

        public List<OrderDTO> GetAll()
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()).CreateMapper();
                return mapper.Map<IEnumerable<Order>, List<OrderDTO>>(db.Orders.GetAll());
            }
            catch (Exception)
            {
                throw new Exception("Cannot GetAll Orders");
            }
        }

        public List<OrderDTO> GetByUserName(string userName)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()).CreateMapper();
                return mapper.Map<IEnumerable<Order>, List<OrderDTO>>(db.Orders.GetAll().Where(x => x.User.Name == userName).ToList());
            }
            catch(Exception)
            {
                throw new Exception("Cannot GetByUserName");
            }
        }

        public void Remove(int id)
        {
            try
            {
                db.Orders.Remove(id);
            }
            catch (Exception)
            {
                throw new Exception("Cannot Remove Order");
            }
        }

        public void Update(OrderDTO entity, int id)
        {
            try
            {
                Order orderEntity = new Order()
                {
                    OrderId = entity.OrderId,
                    UserId = entity.UserId,
                    BookId = entity.BookId
                };
                db.Orders.Update(orderEntity, id);
            }
            catch (Exception)
            {
                throw new Exception("Cannot Update Order");
            }
        }
    }
}
