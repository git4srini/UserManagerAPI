﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UserManager.Domain.Entities
{
    public class User
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfileThumbnailURL { get; set; }
        public string ProfilePictureURL { get; set; }
    }
}
