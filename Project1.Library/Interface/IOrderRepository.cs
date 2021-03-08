
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using Project1.Library.Model;



namespace Project1.Library.Interface
{
    public interface IOrderRepository
    {
        Order Get(int orderId);
        IEnumerable<Order> List();
        IEnumerable<Order> List(Expression<Func<Order, bool>> predicate);
        void Add(Order model);
        void Delete(Order model);
        void Edit(Order model);
        void Save();
    }
}