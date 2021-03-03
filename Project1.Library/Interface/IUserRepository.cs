
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using Project1.Library.Model;



namespace Project1.Library.Interface
{
    public interface IUserRepository
    {
        User GetById(int id);
        IEnumerable<User> List();
        IEnumerable<User> List(Expression<Func<User, bool>> predicate);
        void Add(User model);
        void Delete(User model);
        void Edit(User model);
    }
}