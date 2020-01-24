using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManager.Domain.Entities;
using UserManager.Repository.Filters;
using UserManager.Repository.Interface;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UserManager.Repository.Implementation
{
    /// <summary>
    /// This class contains User related CRUD operations
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly UserManagerDbContext _context;
        public UserRepository(UserManagerDbContext dbContext)
        {
            _context = dbContext;
        }

        /// <summary>
        /// Method to delete user account
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>returns int</returns>
        public async Task<int> Delete(User user)
        {
            int response = 0;
            try
            {
                _context.Users.Remove(user);

                response = await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return response;
        }

        /// <summary>
        /// Method to get specific user details
        /// </summary>
        /// <param name="Id">ID</param>
        /// <returns>user details</returns>
        public async Task<User> GetUserById(ulong Id)
        {
            var user = new User();
            try
            {
                user = await _context.Users.FindAsync((long)Id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return user;
        }

        /// <summary>
        /// Method to get list of users
        /// </summary>
        /// <param name="searchFilter">User Search Filter</param>
        /// <returns>list of users</returns>
        public async Task<IEnumerable<User>> GetUsers(UserSearchFilter searchFilter)
        {
            var userList = new List<User>();
            try
            {
                var dbUsers = _context.Users.AsQueryable();

                if (!string.IsNullOrEmpty(searchFilter.Name))
                {
                    dbUsers = dbUsers.Where(i => i.FirstName.Contains(searchFilter.Name)
                                            || i.LastName.Contains(searchFilter.Name));
                }

                if (searchFilter.DisplayRecordCount > 0)
                {
                    dbUsers = dbUsers.Take((int)searchFilter.DisplayRecordCount);
                }

                userList = await dbUsers.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userList;
        }

        /// <summary>
        /// Method to update user details
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>returns int</returns>
        public async Task<int> Update(User user)
        {
            int response = 0;
            try
            {
                _context.Update(user);

                response = await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return response;
        }        
    }
}
