using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManager.API.Filters;
using UserManager.Application.Filters;
using UserManager.Application.Models;

namespace UserManager.API.Controllers
{
    /// <summary>
    /// This API is to handle User Manager CRUD operations
    /// </summary>
    [ApiController]
    [ApiExceptionFilter]
    public class UserController : ControllerBase
    {
        private readonly Application.UserManager _userManager;
        public UserController(Application.UserManager userManager)
        {
            this._userManager = userManager;
        }

        /// <summary>
        /// This method is to search users.
        /// </summary>
        /// <param name="searchFilter">
        ///     1. Search By First Name or Last Name
        ///     2. Specify the number of records to display
        ///     </param>
        /// <returns>returns list of users</returns>
        [HttpGet]
        [Route("api/[controller]/users")]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUsers([FromQuery] UserSearchFilter searchFilter)
        {
            return Ok(await _userManager.GetUsers(searchFilter));
        }

        /// <summary>
        /// This method is to get specific user details
        /// </summary>
        /// <param name="userId">Enquire by user id</param>
        /// <returns>return user details</returns>
        [HttpGet]
        [Route("api/[controller]/user")]
        public async Task<ActionResult<UserModel>> GetUserById([FromQuery] ulong userId)
        {
            return Ok(await _userManager.GetUserById(userId));
        }

        /// <summary>
        /// This method is to update user details.
        /// </summary>
        /// <param name="userModel">User Model</param>
        /// <returns>returns int value. 0 indicates failure and 1 indicates success</returns>
        [HttpPut]
        [Route("api/[controller]/update")]
        public async Task<ActionResult<int>> UpdateUser([FromBody] UserModel userModel)
        {
            return Ok(await _userManager.Update(userModel));
        }

        /// <summary>
        /// This method is to delete user account.
        /// </summary>
        /// <param name="userId">Delete By user id</param>
        /// <returns>returns int value. 0 indicates failure and 1 indicates success</returns>
        [HttpDelete]
        [Route("api/[controller]/delete")]
        public async Task<ActionResult<int>> DeleteUser([FromQuery] ulong userId)
        {
            return Ok(await _userManager.Delete(userId));
        }
    }
}