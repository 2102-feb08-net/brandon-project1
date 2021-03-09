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



        // Receive customer creation request with details argument
        [HttpPost("api/user/create")]
        public void Create([FromBodyAttribute] Customer customer)
        {
            _userService.SetUserDetails(customer);
        }

        // Receive user existence check request with username argument
        [HttpGet("api/user/check")]
        public bool Check(string username)
        {
            return _userRepository.Get(username) != null;
        }

        // Receive user login request with username and password arguments
        [HttpGet("api/user/login")]
        public IActionResult Login(string username, string password)
        {
            try{
                if (_userService.TryLogin(username, password))
                {
                    return Ok();
                }
                else
                {
                    return NotFound("password invalid");
                }
            }
            catch (InvalidOperationException e)
            {
                s_logger.Debug(e.Message, e);
            }
            
            return NotFound("username invalid");
        }

        // Receive user details request with username argument
        [HttpGet("api/user/details")]
        public IActionResult Details(int id)
        {
            try
            {
                return Ok(_userService.GetCustomerDetails(id));
            }
            catch (ArgumentException e)
            {
                s_logger.Debug(e.Message, e);
            }
            
            return BadRequest();
        }

        [HttpGet("api/user/customerlist")]
        public IEnumerable<Customer> CustomerList()
        {
            try
            {
                return _userService.GetCustomerList();
            }
            catch (InvalidOperationException e)
            {
                s_logger.Debug(e.Message, e);
            }

            return null;
        }
    }
}
