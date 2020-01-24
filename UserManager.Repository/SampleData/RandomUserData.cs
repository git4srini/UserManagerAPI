using System;
using System.Collections.Generic;
using System.Text;

namespace UserManager.Repository.SampleData
{
    public static class RandomUserData
    {
        public static void InitializeData(this UserManagerDbContext context)
        {
            context.Users.AddRange(new Domain.Entities.User[]
                {
                new Domain.Entities.User()
                {
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
                    Title = "Mr",
                    FirstName = "Patrick",
                    LastName = "Anderson",
                    DateOfBirth = DateTime.UtcNow.AddYears(-20),
                    Email = "patrick.anderson@example.com",
                    PhoneNumber = "(384)-062-3305",
                    ProfilePictureURL = "https://randomuser.me/api/portraits/men/99.jpg",
                    ProfileThumbnailURL = "https://randomuser.me/api/portraits/thumb/men/99.jpg"
                },
                new Domain.Entities.User()
                {
                    Title = "Mr",
                    FirstName = "Ramon",
                    LastName = "Morrison",
                    DateOfBirth = DateTime.UtcNow.AddYears(-18),
                    Email = "ramon.morrison@example.com",
                    PhoneNumber = "(862)-772-9196",
                    ProfilePictureURL = "https://randomuser.me/api/portraits/men/12.jpg",
                    ProfileThumbnailURL = "https://randomuser.me/api/portraits/thumb/men/12.jpg"
                },
                new Domain.Entities.User()
                {
                    Title = "Mr",
                    FirstName = "Léandro",
                    LastName = "Barbier",
                    DateOfBirth = DateTime.UtcNow.AddYears(-45),
                    Email = "leandro.barbier@example.com",
                    PhoneNumber = "05-82-23-85-92",
                    ProfilePictureURL = "https://randomuser.me/api/portraits/men/99.jpg",
                    ProfileThumbnailURL = "https://randomuser.me/api/portraits/thumb/men/99.jpg"
                },
                 new Domain.Entities.User()
                {
                    Title = "Mr",
                    FirstName = "Jeremiah",
                    LastName = "Ross",
                    DateOfBirth = DateTime.UtcNow.AddYears(-18),
                    Email = "jeremiah.ross@example.com",
                    PhoneNumber = "(534)-585-2027",
                    ProfilePictureURL = "https://randomuser.me/api/portraits/men/48.jpg",
                    ProfileThumbnailURL = "https://randomuser.me/api/portraits/thumb/men/48.jpg"
                },
                new Domain.Entities.User()
                {
                    Title = "Miss",
                    FirstName = "Cathy",
                    LastName = "Gonzales",
                    DateOfBirth = DateTime.UtcNow.AddYears(-48),
                    Email = "cathy.gonzales@example.com",
                    PhoneNumber = "05-82-23-85-92",
                    ProfilePictureURL = "https://randomuser.me/api/portraits/men/27.jpg",
                    ProfileThumbnailURL = "https://randomuser.me/api/portraits/thumb/men/27.jpg"
                },
                new Domain.Entities.User()
                {
                    Title = "Mr",
                    FirstName = "Léandro",
                    LastName = "Barbier",
                    DateOfBirth = DateTime.UtcNow.AddYears(-38),
                    Email = "leandro.barbier@example.com",
                    PhoneNumber = "016977 5374",
                    ProfilePictureURL = "https://randomuser.me/api/portraits/men/64.jpg",
                    ProfileThumbnailURL = "https://randomuser.me/api/portraits/thumb/men/64.jpg"
                },
                new Domain.Entities.User()
                {
                    Title = "Mr",
                    FirstName = "Sacha",
                    LastName = "Vidal",
                    DateOfBirth = DateTime.UtcNow.AddYears(-22),
                    Email = "sacha.vidal@example.com",
                    PhoneNumber = "01-23-36-89-76",
                    ProfilePictureURL = "https://randomuser.me/api/portraits/men/9.jpg",
                    ProfileThumbnailURL = "https://randomuser.me/api/portraits/thumb/men/9.jpg"
                },
                 new Domain.Entities.User()
                {                   
                    Title = "Mr",
                    FirstName = "Cecil",
                    LastName = "White",
                    DateOfBirth = DateTime.UtcNow.AddYears(-38),
                    Email = "leandro.barbier@example.com",
                    PhoneNumber = "016977 5374",
                    ProfilePictureURL = "https://randomuser.me/api/portraits/men/29.jpg",
                    ProfileThumbnailURL = "https://randomuser.me/api/portraits/thumb/men/29.jpg"
                }
                });

            context.SaveChanges();
        }
    }
}
