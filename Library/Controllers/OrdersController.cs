using AutoMapper;
using BLL.DTOs;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderViewModel>()).CreateMapper();
        IOrderService orderService;
        public OrdersController(IOrderService service)
        {
            orderService = service;
        }
        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<OrderViewModel> Get()
        {
            return mapper.Map<IEnumerable<OrderDTO>, List<OrderViewModel>>(orderService.GetAll());
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public OrderViewModel Get(int id)
        {
            return mapper.Map<OrderDTO, OrderViewModel>(orderService.Get(id));
        }

        // POST api/<OrdersController>
        [HttpPost]
        public void Post([FromBody] OrderViewModel value)
        {
            OrderDTO order = new OrderDTO()
            {
                OrderId = value.OrderId,
                UserId = value.UserId,
                BookId = value.BookId
            };
            orderService.Add(order);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OrderViewModel value)
        {
            OrderDTO order = new OrderDTO()
            {
                OrderId = value.OrderId,
                UserId = value.UserId,
                BookId = value.BookId
            };
            orderService.Update(order, id);
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            orderService.Remove(id);
        }
    }
}
