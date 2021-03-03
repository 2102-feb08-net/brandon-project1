
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using Project1.Library.Model;



namespace Project1.Library.Interface
{
    public interface ICustomerRepository
    {
        Customer GetById(int id);
        IEnumerable<Customer> List();
        IEnumerable<Customer> List(Expression<Func<Customer, bool>> predicate);
        void Add(Customer model);
        void Delete(Customer model);
        void Edit(Customer model);
    }
}