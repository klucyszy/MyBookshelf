using Elibrary.Domain.Entities;
using Elibrary.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;

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
                    CreateDate = new DateTime(2020, 3, 25, 12, 12, 12),
                    UserIdentifier = "106825456884718575110",
                    Login = "klucyszyn1995@gmail.com"
                });

            return builder;
        }
    }
}
