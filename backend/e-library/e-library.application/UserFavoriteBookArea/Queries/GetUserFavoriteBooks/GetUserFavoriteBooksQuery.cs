using AutoMapper;
using AutoMapper.QueryableExtensions;
using Elibrary.Application.Common.Interfaces;
using Elibrary.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Elibrary.Application.UserFavoriteBookArea.Queries.GetUserFavoriteBooks
{
    public class GetUserFavoriteBooksQuery : IRequest<UserFavoriteBooksViewModel>
    {
        public string UserId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetUserFavoriteBooksQuery(string userId, int pageNumber, int pageSize)
        {
            UserId = userId;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public class GetUserFavriteBooksHandler : IRequestHandler<GetUserFavoriteBooksQuery, UserFavoriteBooksViewModel>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetUserFavriteBooksHandler(
                IApplicationDbContext context,
                IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<UserFavoriteBooksViewModel> Handle(
                GetUserFavoriteBooksQuery request, 
                CancellationToken cancellationToken)
            {
                var viewModel = new UserFavoriteBooksViewModel();

                User user = await _context.Users.FirstOrDefaultAsync(x => x.UserIdentifier == request.UserId);
                if (user == null)
                {
                    return null;
                }

                var books = await _context.UserFavoriteBooks
                    .Include(x => x.Book)
                    .Where(x => x.User.Id == user.Id)
                    .ProjectTo<UserFavoriteBookDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                viewModel.FavoriteBooks = books;
                viewModel.ApplyPagination(request.PageNumber, request.PageSize, viewModel.FavoriteBooks.Count);

                return viewModel;
            }
        }
    }   
}
