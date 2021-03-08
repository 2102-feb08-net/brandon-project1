using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

using Project1.Library.Interface;
using Project1.Library.Model;
using Project1.Library.Service;
using Project1.Data;

namespace Project1.WebUI.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        // each method here ("action method") will respond to one type of AJAX request
        // from the app, and optionally return an object (will be serialized to
        // json by ASP.NET and System.Text.Json in the response body)

        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        private static readonly ILogger s_logger = LogManager.GetCurrentClassLogger();

        public UserController(IUserRepository userRepository, IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }



        // Receive user creation request with username, password, and details arguments
        [HttpPost("api/user/create")]
        public void Create(string username, string password, [FromBodyAttribute] Customer customer)
        {
            if (Check(username) == false)
            {
                var user = new Library.Model.User{
                    Username = username,
                    Password = password
                };
                _userRepository.Add(user);
                _userRepository.Save();
                customer.UserId = _userRepository.Get(username).UserId;;
                _userService.SetUserDetails(customer);
            }
            else
            {
                Console.WriteLine("User with this username already exists");
            }
        }

        // Receive user existence check request with username argument
        [HttpGet("api/user/check")]
        public bool Check(string username)
        {
            return _userRepository.Get(username) != null;
        }

        // Receive user login request with username and password arguments
        [HttpGet("api/user/login")]
        public bool Login(string username, string password)
        {
            return _userService.TryLogin(username, password);
        }

        // Receive user details request with username argument
        [HttpGet("api/user/details")]
        public Customer Details(string username)
        {
            try
            {
                return _userService.GetUserDetails(username);
            }
            catch (ArgumentException e)
            {
                s_logger.Debug(e.Message, e);
            }
            
            return null;
        }


    }
}
