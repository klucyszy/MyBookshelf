using AutoMapper;
using AutoMapper.QueryableExtensions;
using Elibrary.Application.Common.Interfaces;
using Elibrary.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Elibrary.Application.UserFavoriteBookArea.Queries.GetUserFavoriteBooks
{
    public class GetUserFavoriteBooksQuery : IRequest<UserFavoriteBooksViewModel>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetUserFavoriteBooksQuery(int pageNumber, int pageSize)
        {
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

            public async Task<UserFavoriteBooksViewModel> Handle(GetUserFavoriteBooksQuery request, CancellationToken cancellationToken)
            {
                var viewModel = new UserFavoriteBooksViewModel();

                viewModel.FavoriteBooks = await _context.UserFavoriteBooks
                    .ProjectTo<UserFavoriteBookDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
                viewModel.ApplyPagination(request.PageNumber, request.PageSize, viewModel.FavoriteBooks.Count);

                return viewModel;
            }
        }
    }   
}
