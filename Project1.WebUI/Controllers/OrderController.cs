using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Project1.Library.Interface;
using Project1.Library.Model;
using Project1.Library.Service;
using Project1.Data;

namespace Project1.WebUI.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        // each method here ("action method") will respond to one type of AJAX request
        // from the app, and optionally return an object (will be serialized to
        // json by ASP.NET and System.Text.Json in the response body)

        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }



        // Receive user creation request with username and password arguments
        [HttpPost("api/order/create")]
        public void Create(Order order, string option)
        {
            _orderRepository.Add(order);
            _orderRepository.Save();
        }

        // Receive user details request with username argument
        [HttpGet("api/order/details")]
        public Order Details(int orderId)
        {
            return _orderRepository.Get(orderId);
        }


    }
}
