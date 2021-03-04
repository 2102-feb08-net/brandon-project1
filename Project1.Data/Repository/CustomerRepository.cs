
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using Project1.Library.Interface;
using Project1.Data.Entity;

namespace Project1.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ProjectDBContext _customerContext;

        public CustomerRepository(ProjectDBContext context) 
        {
            _customerContext = context;
        }



        public Library.Model.Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Library.Model.Customer> List()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Library.Model.Customer> List(Expression<Func<Library.Model.Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(Library.Model.Customer model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Library.Model.Customer model)
        {
            throw new NotImplementedException();
        }

        public void Edit(Library.Model.Customer model)
        {
            throw new NotImplementedException();
        }
    }
}