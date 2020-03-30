using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oficios.Data;
using Oficios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficios.Controllers
{
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        [HttpGet("")]
        public async Task<ActionResult<User[]>> GetUsers()
        {
            try
            {
                var results = await _userRepository.GetUsersAsync();
                Console.WriteLine(results); //Insert Logger here
                return this.StatusCode(StatusCodes.Status200OK, results);
            }catch(Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Exception found: {e.Message}");
            }
            
        }
        
    }
}
