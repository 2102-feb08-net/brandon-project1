
using System;
using System.Collections.Generic;
using System.Linq;

using Project1.Library.Interface;
using Project1.Library.Model;

namespace Project1.Library.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICustomerRepository _customerRepository;

        public UserService(IUserRepository userRepository, ICustomerRepository customerRepository)
        {
            _userRepository = userRepository;
            _customerRepository = customerRepository;
        }


        public bool TryLogin(string username, string password)
        {
            if (username == null || password == null)
            {
                throw new ArgumentNullException("Username and password must not be null." );
            }
            User user = _userRepository.Get(username);
            
            return user != null;
        }

        public Customer GetUserDetails(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Username must not be null");
            }

            var user = _userRepository.Get(username);
            if (user == null)
            {
                throw new ArgumentException("User with username " + username + " not found.");
            }
            var customer = _customerRepository.List()
                .First(c => c.UserId == user.UserId);
            return customer;
        }

        public void SetUserDetails(Customer customer)
        {
            _customerRepository.Add(customer);
            _customerRepository.Save();
        }
    }
}