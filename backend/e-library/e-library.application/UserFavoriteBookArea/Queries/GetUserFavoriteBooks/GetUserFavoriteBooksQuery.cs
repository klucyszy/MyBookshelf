using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Elibrary.Application.UserFavoriteBookArea.Queries.GetUserFavoriteBooks
{
    public class GetUserFavoriteBooksQuery : IRequest<UserFavoriteBooksViewModel>
    {
        public class GetUserFavriteBooksHandler : IRequestHandler<GetUserFavoriteBooksQuery, UserFavoriteBooksViewModel>
        {
            public Task<UserFavoriteBooksViewModel> Handle(GetUserFavoriteBooksQuery request, CancellationToken cancellationToken)
            {
                throw new Exception();
            }
        }
    }   
}
