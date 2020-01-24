using System;
using System.Linq;
using System.Threading.Tasks;
using UserManager.Application.Models;
using UserManager.Repository;
using UserManager.Repository.Interface;
using Xunit;

namespace UserManager.Test
{
    [Collection("QueryCollection")]
    public class UserManager_Test
    {
        private readonly UserManagerDbContext _context;
        private readonly IUserRepository _userRepository;
        public UserManager_Test(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _userRepository = new Repository.Implementation.UserRepository(_context);
        }

        [Fact]
        public async Task GetUsers_ShouldReturnAllData_Test()
        {
            var expected = _context.Users.Count();

            Application.UserManager userManager = new Application.UserManager(_userRepository);

            var searchFilter = new Application.Filters.UserSearchFilter();

            var actual = await userManager.GetUsers(searchFilter);

            Assert.Equal(expected, actual.Count());
        }

        [Fact]
        public async Task GetUsers_ShouldReturnOnlyTwoRecords_Test()
        {
            var expectedCount = 2;

            Application.UserManager userManager = new Application.UserManager(_userRepository);

            var searchFilter = new Application.Filters.UserSearchFilter() { DisplayRecordCount = 2 };

            var actual = await userManager.GetUsers(searchFilter);

            Assert.Equal(expectedCount, actual.Count());
        }

        [Fact]
        public async Task GetUsers_ShouldReturnOnly_WithFilteredName_Test()
        {
            string name = "mar";

            var expectedCount = _context.Users.Where(i => i.FirstName.Contains(name) || i.LastName.Contains(name)).Count();

            Application.UserManager userManager = new Application.UserManager(_userRepository);

            var searchFilter = new Application.Filters.UserSearchFilter() { Name = name };

            var actual = await userManager.GetUsers(searchFilter);

            Assert.Equal(expectedCount, actual.Count());
        }

        [Fact]
        public async Task GetUsers_ShouldReturnOnly_WithFilteredNameAndDisplayRecordCount_Test()
        {
            string name = "mar";
            int displayCount = 5;

            var expectedCount = _context.Users
                                        .Where(i => i.FirstName.Contains(name) || i.LastName.Contains(name))
                                        .Take(displayCount).Count();

            Application.UserManager userManager = new Application.UserManager(_userRepository);

            var searchFilter = new Application.Filters.UserSearchFilter() { Name = name, DisplayRecordCount = displayCount };

            var actual = await userManager.GetUsers(searchFilter);

            Assert.Equal(expectedCount, actual.Count());
        }

        [Fact]
        public async Task GetUserById_ShouldReturnValidData_Test()
        {
            ulong userId = 1;
            
            Application.UserManager userManager = new Application.UserManager(_userRepository);

            var actual = await userManager.GetUserById(userId);

            Assert.NotNull(actual);
        }

        [Fact]
        public Task GetUserById_ShouldThrowInvalidException_Test()
        {
            ulong userId = 10;

            Application.UserManager userManager = new Application.UserManager(_userRepository);

            Assert.ThrowsAsync<ArgumentException>(()=> userManager.GetUserById(userId));

            return Task.CompletedTask;
        }

        [Fact]
        public async Task UpdateUser_ShouldUpdateUserDeetails_Test()
        {
            var userModel = new UserModel()
            {
                ID = 2,
                DateOfBirth = DateTime.UtcNow.AddYears(-26),
                Email = "test@example.com",
                PhoneNumber = "123456780",
                Name = new Name() { FirstName = "Srini", LastName = "Vasan", Title = "Mr" },
                Picture = new Picture() 
                {
                    ProfilePictureURL = "https://randomuser.me/api/portraits/men/30.jpg",
                    ProfileThumbnailURL = "https://randomuser.me/api/portraits/thumb/men/30.jpg"
                }
            };

            Application.UserManager userManager = new Application.UserManager(_userRepository);

            var result = await userManager.Update(userModel);

            var actual = await _context.Users.FindAsync(userModel.ID);

            Assert.True(Convert.ToBoolean(result));
            Assert.Equal(userModel.Email, actual.Email);
            Assert.Equal(userModel.DateOfBirth, actual.DateOfBirth);
            Assert.Equal(userModel.PhoneNumber, actual.PhoneNumber);
            Assert.Equal(userModel.Name.FirstName, actual.FirstName);
            Assert.Equal(userModel.Name.LastName, actual.LastName);
            Assert.Equal(userModel.Name.Title, actual.Title);
            Assert.Equal(userModel.Picture.ProfilePictureURL, actual.ProfilePictureURL);
            Assert.Equal(userModel.Picture.ProfileThumbnailURL, actual.ProfileThumbnailURL);
        }

        [Fact]
        public Task UpdateUser_ShouldThrowException_WhenUserModelIsNull_Test()
        {
            Application.UserManager userManager = new Application.UserManager(_userRepository);

            Assert.ThrowsAsync<ArgumentNullException>(() => userManager.Update(null));

            return Task.CompletedTask;
        }

        [Fact]
        public Task UpdateUser_ShouldThrowException_WhenUserIdIsInvalid_Test()
        {
            var userModel = new UserModel()
            {
                ID = 12,
                DateOfBirth = DateTime.UtcNow.AddYears(-26),
                Email = "test@example.com",
                PhoneNumber = "123456780",
                Name = new Name() { FirstName = "Srini", LastName = "Vasan", Title = "Mr" },
                Picture = new Picture()
                {
                    ProfilePictureURL = "https://randomuser.me/api/portraits/men/30.jpg",
                    ProfileThumbnailURL = "https://randomuser.me/api/portraits/thumb/men/30.jpg"
                }
            };

            Application.UserManager userManager = new Application.UserManager(_userRepository);

            Assert.ThrowsAsync<ArgumentException>(() => userManager.Update(userModel));

            return Task.CompletedTask;
        }

        [Fact]
        public  async Task DeleteUser_ShouldDeleteUserAccount_Test()
        {
            ulong userId = 5;

            Application.UserManager userManager = new Application.UserManager(_userRepository);

            var result = await userManager.Delete(userId);

            Assert.True(Convert.ToBoolean(result));

        }

        [Fact]
        public Task DeleteUser_ShouldThrowException_WhenUserIdIsInvalid_Test()
        {
            ulong userId = 55;

            Application.UserManager userManager = new Application.UserManager(_userRepository);

            Assert.ThrowsAsync<ArgumentException>(() => userManager.Delete(userId));

            return Task.CompletedTask;

        }

    }
}
