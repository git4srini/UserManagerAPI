using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManager.Application.Filters;
using UserManager.Application.Models;
using UserManager.Domain.Entities;
using UserManager.Repository.Interface;
using Repository = UserManager.Repository.Filters;

namespace UserManager.Application
{
    /// <summary>
    /// 
    /// </summary>
    public class UserManager
    {
        private readonly IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchFilter"></param>
        /// <returns></returns>
        public async Task<IEnumerable<UserModel>> GetUsers(UserSearchFilter searchFilter)
        {
            var userList = new List<UserModel>();
            try
            {
                if(searchFilter is null)
                {
                    throw new ArgumentNullException(nameof(UserSearchFilter));
                }

                var dbSearchFilter = new Repository.Filters.UserSearchFilter()
                {
                    Name = searchFilter.Name,
                    DisplayRecordCount = searchFilter.DisplayRecordCount
                };

                var dbUserList = await _userRepository.GetUsers(dbSearchFilter);

                dbUserList.ToList().ForEach(item=> 
                {
                    userList.Add(new UserModel()
                    {
                        ID = item.ID,
                        Email = item.Email,
                        DateOfBirth = item.DateOfBirth,
                        PhoneNumber = item.PhoneNumber,
                        Name = new Name()
                        {                           
                            FirstName = item.FirstName,
                            LastName = item.LastName,
                            Title = item.Title
                        },
                        Picture = new Picture() { ProfileThumbnailURL = item.ProfileThumbnailURL }
                    });
                });

            }
            catch(Exception ex)
            {
                throw ex;
            }
            return userList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserModel> GetUserById(ulong userId)
        {
            var userDetails = new UserModel();
            try
            {
                var dbUserData = await _userRepository.GetUserById(userId);

                if (dbUserData is null)
                {
                    throw new ArgumentException("Invalid input. Record not found!");
                }

                userDetails = new UserModel()
                {
                    ID = dbUserData.ID,
                    Email = dbUserData.Email,
                    DateOfBirth = dbUserData.DateOfBirth,
                    PhoneNumber = dbUserData.PhoneNumber,
                    Name = new Name()
                    {
                        FirstName = dbUserData.FirstName,
                        LastName = dbUserData.LastName,
                        Title = dbUserData.Title
                    },
                    Picture = new Picture() { ProfilePictureURL = dbUserData.ProfilePictureURL }
                };                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userDetails;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<int> Update(UserModel user)
        {
            int response = 0;
            try
            {
                if(user is null)
                {
                    throw new ArgumentNullException("User");
                }

                var userData = await _userRepository.GetUserById((ulong)user.ID);

                if (userData is null)
                {
                    throw new ArgumentException("Invalid input. Record not found!");
                }

                userData.DateOfBirth = user.DateOfBirth;
                userData.Email = user.Email;
                userData.Title = user.Name.Title;
                userData.FirstName = user.Name.FirstName;
                userData.LastName = user.Name.LastName;
                userData.PhoneNumber = user.PhoneNumber;
                userData.ProfilePictureURL = user.Picture.ProfilePictureURL;
                userData.ProfileThumbnailURL = user.Picture.ProfileThumbnailURL;

                response = await _userRepository.Update(userData);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<int> Delete(ulong userId)
        {
            int response = 0;
            try
            {
                var userData = await _userRepository.GetUserById(userId);

                if (userData is null)
                {
                    throw new ArgumentException("Invalid input. Record not found!");
                }

                response = await _userRepository.Delete(userData);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return response;
        }


    }
}
