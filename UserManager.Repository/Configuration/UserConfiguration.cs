using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UserManager.Domain.Entities;

namespace UserManager.Repository.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(item => item.ID)
                    .UseIdentityColumn();
            builder.Property(item => item.Title)
                    .HasMaxLength(5);
            builder.Property(item => item.FirstName)
                   .HasMaxLength(50).IsRequired();
            builder.Property(item => item.LastName)
                    .HasMaxLength(50)
                    .IsRequired();
            builder.Property(item => item.DateOfBirth)
                    .IsRequired();
            builder.Property(item => item.Email)
                   .HasMaxLength(100)
                   .IsRequired();
            builder.Property(item => item.PhoneNumber)
                    .HasMaxLength(20)
                    .IsRequired();
            builder.Property(item => item.ProfileThumbnailURL)
                    .HasMaxLength(100)
                    .IsRequired();
            builder.Property(item => item.ProfilePictureURL)
                   .HasMaxLength(100)
                   .IsRequired();
        }
    }
}
