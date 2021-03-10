
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
                throw new ArgumentNullException();
            }
            User user = _userRepository.Get(username);
            
            return user.Password == password;
        }

        public IEnumerable<Customer> GetCustomerList()
        {
            return _customerRepository.List();
        }

        public Customer GetCustomerDetails(int customerId)
        {
            var customer = _customerRepository.GetById(customerId);
            return customer;
        }

        public void SetUserDetails(Customer customer)
        {
            _customerRepository.Add(customer);
            _customerRepository.Save();
        }
    }
}