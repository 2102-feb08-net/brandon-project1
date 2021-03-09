
using System.Collections.Generic;

using Project1.Library.Model;



namespace Project1.Library.Service
{
    public interface IUserService
    {
        bool TryLogin(string username, string password);
        IEnumerable<Customer> GetCustomerList();
        Customer GetCustomerDetails(int customerId);
        void SetUserDetails(Customer customer);
    }
}