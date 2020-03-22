using AutoMapper;
using Elibrary.Application.Common.Mappings;
using Elibrary.Domain.Entities;

namespace Elibrary.Application.UserFavoriteBookArea.Queries.GetUserFavoriteBooks
{
    public class UserFavoriteBookDto : IMapFrom<UserFavoriteBook>
    {
        public int Rate { get; set; }
        public string Comment { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserFavoriteBook, UserFavoriteBookDto>();
        }
    }
}
