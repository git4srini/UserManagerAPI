using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserManager.Application.Models
{
    public class UserModel
    {
        public long ID { get; set; }
        public Name Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Valid email address required!")]
        public string Email { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "Phone Number should be less than or equal to 5 characters")]
        public string PhoneNumber { get; set; }
        public Picture Picture { get; set; }

    }

    public class Name
    {
        [Required]
        [MaxLength(5, ErrorMessage = "Title should be less than or equal to 5 characters")]
        public string Title { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "First Name should be less than or equal to 5 characters")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Last Name should be less than or equal to 5 characters")]
        public string LastName { get; set; }
    }

    public class Picture
    {
        [Required]
        public string ProfileThumbnailURL { get; set; }
        [Required]
        public string ProfilePictureURL { get; set; }
    }
}
