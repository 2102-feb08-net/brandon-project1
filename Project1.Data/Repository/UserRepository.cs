
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Project1.Data.Entity;
using Project1.Library.Interface;


namespace Project1.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ProjectDBContext _userContext;

        public UserRepository(ProjectDBContext context) 
        {
            _userContext = context;
        }



        public Library.Model.User Get(string username)
        {
            var user = _userContext.Users
                .Select(u => u)
                .Where(u => u.Username == username)
                .First();
            return new Library.Model.User
            {
                Username = user.Username,
                Password = user.Password
            };
        }

        public IEnumerable<Library.Model.User> List()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Library.Model.User> List(Expression<Func<Library.Model.User, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        
        public void Add(Library.Model.User model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Library.Model.User model)
        {
            throw new NotImplementedException();
        }

        public void Edit(Library.Model.User model)
        {
            throw new NotImplementedException();
        }
    }
}