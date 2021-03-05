
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Project1.Library.Model;
using Project1.Library.Interface;


namespace Project1.Test.Library.Service.Mock
{
    public class MockUserRepository : IUserRepository
    {

        public User Get(string username)
        {
            return new User();
        }

        public IEnumerable<User> List()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> List(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        
        public void Add(User model)
        {
            throw new NotImplementedException();
        }

        public void Delete(User model)
        {
            throw new NotImplementedException();
        }

        public void Edit(User model)
        {
            throw new NotImplementedException();
        }
    }
}