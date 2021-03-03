
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using Project1.Library.Interface;
using Project1.Library.Model;


namespace Project1.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        public User GetById(int id)
        {
            throw new NotImplementedException();
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