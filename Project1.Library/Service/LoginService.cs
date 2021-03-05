
using Project1.Library.Interface;

namespace Project1.Library.Service
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }



        public bool TryLogin(string username, string password)
        {
            return false;
        }
    }
}