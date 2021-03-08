
using Project1.Library.Model;

namespace Project1.Library.Service
{
    public interface IUserService
    {
        bool TryLogin(string username, string password);
        Customer GetUserDetails(string username);
        void SetUserDetails(Customer customer);
    }
}