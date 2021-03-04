using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Project1.Library.Interface;
using Project1.Library.Model;
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
        //private readonly IInboxCleaner _inboxCleaner;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }



        // distinguish what HTTP method (GET, POST, etc.) this will accept, and, what URL
        [HttpGet("api/user")]
        public User GetUser(string username)
        {
            return _userRepository.Get(username);
        }

    }
}
