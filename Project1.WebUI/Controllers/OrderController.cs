using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

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
        private readonly ILocationRepository _locationRepository;

        private static readonly ILogger s_logger = LogManager.GetCurrentClassLogger();

        public OrderController(IOrderRepository orderRepository, ILocationRepository locationRepository)
        {
            _orderRepository = orderRepository;
            _locationRepository = locationRepository;
        }



        // Receive order creation request with order details argument
        [HttpPost("api/order/create")]
        public void Create(Order order, string option)
        {
            // check and update location inventory
            var location = _locationRepository.GetById(order.LocationId);
            var inventory = location.Inventory;
            foreach (OrderLine ol in order.OrderLines)
            {
                inventory.ForEach(p => Console.WriteLine(p.ProductId + ", " + ol.ProductId));
                try {
                    var inventoryLine = inventory.First(p => p.ProductId == ol.ProductId);
                    if (inventoryLine.Quantity < ol.Quantity)
                    {
                        s_logger.Warn($"Order to be added cannot be fullfilled by location ({order.LocationId}): ignoring.");
                        return;
                    }
                }
                catch (InvalidOperationException e)
                {
                    s_logger.Warn(e.Message, e);
                    return;
                }
            }
            foreach(OrderLine ol in order.OrderLines)
            {
                var inventoryLine = inventory.First(p => p.ProductId == ol.ProductId);
                inventoryLine.Quantity -= ol.Quantity;
            }
            _locationRepository.Edit(location);

            // create order
            _orderRepository.Add(order);

            // save DB changes
            _locationRepository.Save();
            _orderRepository.Save();
        }

        // Receive orders details request with order id argument
        [HttpGet("api/order/details")]
        public Order Details(int orderId)
        {
            return _orderRepository.Get(orderId);
        }

        // Receive customer order history request with customer id argument
        [HttpGet("api/order/customerhistory")]
        public List<Order> UserHistory(int customerId)
        {
            throw new NotImplementedException();
        }

        // Receive location order history request with location id argument
        [HttpGet("api/order/locationhistory")]
        public List<Order> LocationHistory(int locationId)
        {
            throw new NotImplementedException();
        }
    }
}
