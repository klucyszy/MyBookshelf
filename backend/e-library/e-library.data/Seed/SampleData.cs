using Elibrary.Domain.Entities;
using Elibrary.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elibrary.Data.Seed
{
    public static class SampleData
    {
        public static ModelBuilder CreateSampleData(this ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    CreatedBy = "admin",
                    CreateDate = new DateTime(2020, 3, 25),
                    UserIdentifier = "testId",
                    Login = "testUser"
                },
                new User
                {
                    Id = 2,
                    CreatedBy = "admin",
                    CreateDate = new DateTime(2020, 3, 25, 12, 12, 12),
                    UserIdentifier = "106825456884718575110",
                    Login = "klucyszyn1995@gmail.com"
                });

            builder.Entity<Book>().HasData(
                new Book 
                {
                    Id = 1,
                    CreatedBy = "admin",
                    CreateDate = new DateTime(2020, 1, 1),
                    ISBN = "ISBN-1",
                    Title = "Gettings Things Done",
                    Author = "David Allen",
                    Category = Category.Psychology
                },
                new Book
                {
                    Id = 2,
                    CreatedBy = "admin",
                    CreateDate = new DateTime(2020, 1, 1),
                    ISBN = "ISBN-2",
                    Title = "Siła Nawyku",
                    Author = "Charles Duhigg",
                    Category = Category.Psychology
                },
                new Book
                {
                    Id = 3,
                    CreatedBy = "admin",
                    CreateDate = new DateTime(2020, 1, 1),
                    ISBN = "ISBN-3",
                    Title = "Pułapki Myślenia",
                    Author = "Daniel Kahneman",
                    Category = Category.Psychology
                });

            builder.Entity<UserFavoriteBook>().HasData(
                new UserFavoriteBook
                {
                    Id = 1,
                    Rate = 8,
                    BookId = 1,
                    UserId = 2,
                },
                new UserFavoriteBook
                {
                    Id = 2,
                    Rate = 9,
                    BookId = 2,
                    UserId = 2,
                });


            return builder;
        }
    }
}
