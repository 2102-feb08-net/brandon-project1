
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using Project1.Library.Interface;
using Project1.Library.Model;

namespace Project1.Test.Library.Service.Mock
{
    public class MockCustomerRepository : ICustomerRepository
    {
        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> List()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> List(Expression<Func<Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(Customer model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer model)
        {
            throw new NotImplementedException();
        }

        public void Edit(Customer model)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}