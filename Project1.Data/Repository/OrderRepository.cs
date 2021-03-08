
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NLog;

using Project1.Data.Entity;
using Project1.Library.Interface;



namespace Project1.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ProjectDBContext _orderContext;

        private static readonly ILogger s_logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a OrderRepository instance given a suitable data source.
        /// </summary>
        /// <param name="context">The data source</param>
        public OrderRepository(ProjectDBContext context) 
        {
            _orderContext = context;
        }


        /// <summary>
        /// Get first order with match on Order.OrderId
        /// </summary>
        /// <returns>The matched order</returns>
        public Library.Model.Order Get(int orderId)
        {
            try {
                Order order = _orderContext.Orders
                    .Include(o => o.OrderLines)
                    .ThenInclude(ol => ol.Product)
                    .AsNoTracking()
                    .First(o => o.OrderId == orderId);

                return new Library.Model.Order
                {
                    OrderId = order.OrderId,
                    CustomerId = order.CustomerId,
                    LocationId = order.LocationId,
                    OrderTime = order.OrderTime,
                    OrderTotal = order.OrderTotal,

                    OrderLines = order.OrderLines.Select(ol => new Library.Model.OrderLine
                    {
                        OrderLineId = ol.OrderLineId,
                        OrderId = ol.OrderId,
                        Product = new Library.Model.Product
                        {
                            ProductId = ol.Product.ProductId,
                            Name = ol.Product.Name,
                            BestBy = ol.Product.BestBy,
                            UnitPrice = ol.Product.UnitPrice
                        },
                        Quantity = ol.Quantity
                    }).ToList()
                };
            }
            catch (InvalidOperationException e)
            {
                s_logger.Debug(e.Message, e);
            }
            
            return null;
        }

        public IEnumerable<Library.Model.Order> List()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Library.Model.Order> List(Expression<Func<Library.Model.Order, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add and save new orders to store locations for customers.
        /// </summary>
        public void Add(Library.Model.Order model)
        {
            if (model.OrderId != 0)
            {
                s_logger.Warn($"Order to be added has an ID ({model.OrderId}) already: ignoring.");
                return;
            }
            foreach (Library.Model.OrderLine ol in model.OrderLines)
            {
                if (ol.OrderLineId != 0)
                {
                    s_logger.Warn($"OrderLine to be added has an ID ({ol.OrderLineId}) already: ignoring.");
                    return;
                }
            }

            s_logger.Info($"Adding Order");

            var products = _orderContext.Products
                .AsNoTracking();

            // ID left at default 0
            Order entity = new Order
            {
                CustomerId = model.CustomerId,
                LocationId = model.LocationId,
                OrderTime = model.OrderTime,
                OrderTotal = 0.00M
            };
            _orderContext.Add(entity);

            foreach (Library.Model.OrderLine ol in model.OrderLines)
            {
                OrderLine entity2 = new OrderLine
                {
                    Order = entity,
                    ProductId = ol.ProductId,
                    Quantity = ol.Quantity,
                    LineTotal = ol.Quantity * products.First(p => p.ProductId == ol.ProductId).UnitPrice
                };
                entity.OrderTotal += entity2.LineTotal;
                _orderContext.Add(entity2);
            }
        }

        public void Delete(Library.Model.Order model)
        {
            throw new NotImplementedException();
        }

        public void Edit(Library.Model.Order model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Persist changes to the data source.
        /// </summary>
        public void Save()
        {
            s_logger.Info("Saving changes to the database");
            _orderContext.SaveChanges();
        }
    }
}