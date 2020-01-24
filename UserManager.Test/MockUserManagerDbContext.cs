using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserManager.Repository;

namespace UserManager.Test
{
    public class MockUserManagerDbContext
    {
        public static UserManagerDbContext Create()
        {
            var options = new DbContextOptionsBuilder<UserManagerDbContext>()
               .UseInMemoryDatabase(Guid.NewGuid().ToString())
               .Options;

            var context = new UserManagerDbContext(options);

            context.Database.EnsureCreated();

            context.Users.AddRange(new Domain.Entities.User[] 
            {
                new Domain.Entities.User()
                {
                    ID = 1,
                    Title = "Ms",
                    FirstName = "Margaux",
                    LastName = "Renard",
                    DateOfBirth = DateTime.UtcNow.AddYears(-25),
                    Email = "margaux.renard@example.com",
                    PhoneNumber = "04-10-61-43-38",
                    ProfilePictureURL = "https://randomuser.me/api/portraits/women/65.jpg",
                    ProfileThumbnailURL = "https://randomuser.me/api/portraits/thumb/women/65.jpg"
                },
                new Domain.Entities.User()
                {
                    ID = 2,
                    Title = "Mr",
                    FirstName = "Silas",
                    LastName = "Jensen",
                    DateOfBirth = DateTime.UtcNow.AddYears(-23),
                    Email = "silas.jensen@example.com",
                    PhoneNumber = "81304054",
                    ProfilePictureURL = "https://randomuser.me/api/portraits/men/77.jpg",
                    ProfileThumbnailURL = "https://randomuser.me/api/portraits/thumb/men/77.jpg"
                },
                new Domain.Entities.User()
                {
                    ID = 3,
                    Title = "Mrs",
                    FirstName = "Lucy",
                    LastName = "Petit",
                    DateOfBirth = DateTime.UtcNow.AddYears(-24),
                    Email = "lucy.petit@example.com",
                    PhoneNumber = "03-35-42-32-99",
                    ProfilePictureURL = "https://randomuser.me/api/portraits/women/2.jpg",
                    ProfileThumbnailURL = "https://randomuser.me/api/portraits/thumb/women/2.jpg"
                },
                new Domain.Entities.User()
                {
                    ID = 4,
                    Title = "Mrs",
                    FirstName = "Freja",
                    LastName = "Kristensen",
                    DateOfBirth = DateTime.UtcNow.AddYears(-19),
                    Email = "freja.kristensen@example.com",
                    PhoneNumber = "37660020",
                    ProfilePictureURL = "https://randomuser.me/api/portraits/women/50.jpg",
                    ProfileThumbnailURL = "https://randomuser.me/api/portraits/thumb/women/50.jpg"
                },
                new Domain.Entities.User() 
                {
                    ID= 5,
                    Title = "Mr",
                    FirstName = "Patrick",
                    LastName = "Anderson",
                    DateOfBirth = DateTime.UtcNow.AddYears(-20),
                    Email = "patrick.anderson@example.com",
                    PhoneNumber = "(384)-062-3305",
                    ProfilePictureURL = "https://randomuser.me/api/portraits/men/99.jpg",
                    ProfileThumbnailURL = "https://randomuser.me/api/portraits/thumb/men/99.jpg"
                }
            });

            context.SaveChanges();

            return context;
        }

        public static void Destroy(UserManagerDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
