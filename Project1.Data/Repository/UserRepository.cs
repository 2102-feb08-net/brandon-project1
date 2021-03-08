
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NLog;

using Project1.Data.Entity;
using Project1.Library.Interface;


namespace Project1.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ProjectDBContext _userContext;

        private static readonly ILogger s_logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a UserRepository instance given a suitable data source.
        /// </summary>
        /// <param name="context">The data source</param>
        public UserRepository(ProjectDBContext context) 
        {
            _userContext = context;
        }


        /// <summary>
        /// Get first user with match on User.Username
        /// </summary>
        /// <returns>The matched user</returns>
        public Library.Model.User Get(string username)
        {
            try {
                var user = _userContext.Users
                    .First(u => u.Username == username);

                return new Library.Model.User
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    Password = user.Password
                };
            }
            catch (InvalidOperationException e)
            {
                s_logger.Debug(e.Message, e);
            }
            
            return null;
        }

        public IEnumerable<Library.Model.User> List()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Library.Model.User> List(Expression<Func<Library.Model.User, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Add a new user.
        /// </summary>
        public void Add(Library.Model.User model)
        {
            if (model.UserId != 0)
            {
                s_logger.Warn($"Customer to be added has an ID ({model.UserId}) already: ignoring.");
            }

            s_logger.Info($"Adding Customer");

            // ID left at default 0
            User entity = new User
            {
                Username = model.Username,
                Password = model.Password
            };
            _userContext.Add(entity);
        }

        public void Delete(Library.Model.User model)
        {
            throw new NotImplementedException();
        }

        public void Edit(Library.Model.User model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Persist changes to the data source.
        /// </summary>
        public void Save()
        {
            s_logger.Info("Saving changes to the database");
            _userContext.SaveChanges();
        }
    }
}