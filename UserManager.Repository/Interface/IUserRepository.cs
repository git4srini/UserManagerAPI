using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManager.Domain.Entities;
using UserManager.Repository.Filters;

namespace UserManager.Repository.Interface
{
    public interface IUserRepository
    {
        /// <summary>
        /// Method to get list of users
        /// </summary>
        /// <param name="searchFilter">User Search Filter</param>
        /// <returns>list of users</returns>
        Task<IEnumerable<User>> GetUsers(UserSearchFilter searchFilter);
        /// <summary>
        /// Method to get specific user details
        /// </summary>
        /// <param name="Id">ID</param>
        /// <returns>user details</returns>
        Task<User> GetUserById(ulong Id);
        /// <summary>
        /// Method to update user details
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>returns int</returns>
        Task<int> Update(User user);
        /// <summary>
        /// Method to delete user account
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>returns int </returns>
        Task<int> Delete(User user);
    }
}
