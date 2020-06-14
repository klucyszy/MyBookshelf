using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Elibrary.Application.Common.Interfaces;
using Elibrary.Application.Common.Models;
using Elibrary.Application.GoogleBooks.Interfaces;
using Google.Apis.Books.v1;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Elibrary.Application.BookshelfsArea.Command.AddFavoriteBookshelf
{
    public class AddFavoriteBookshelfCommand : IRequest<ApiModel>
    {
        public AddFavoriteBookshelfCommand(string userId, int bookshelfId)
        {
            UserId = userId;
            BookshelfId = bookshelfId;
        }

        public int BookshelfId { get; set; }
        public string UserId { get; set; }


        public class AddFavoriteBookshelfCommandHandler : IRequestHandler<AddFavoriteBookshelfCommand, ApiModel>
        {
            private readonly BooksService _booksService;
            private readonly IApplicationDbContext _context;


            public AddFavoriteBookshelfCommandHandler(
                IGoogleBooksServiceFactory googleBooksServiceFactory,
                IApplicationDbContext applicationDbContext)
            {
                _booksService = googleBooksServiceFactory.GetBooksService();
                _context = applicationDbContext;
            }

            public async Task<ApiModel> Handle(AddFavoriteBookshelfCommand request, CancellationToken cancellationToken)
            {
                var bookshelves = await _booksService.Mylibrary.Bookshelves.List().ExecuteAsync();
                var bookshelf = bookshelves?.Items?.FirstOrDefault(x => x.Id == request.BookshelfId);
                if(bookshelf == null)
                {
                    return ApiModel.NotFound();
                }

                bool isFavorite = await _context.FavoriteBookshelves
                    .AnyAsync(x => x.BookshelfId == request.BookshelfId.ToString() && x.UserId == request.UserId);
                if (isFavorite)
                {
                    return ApiModel.Created();
                }

                _context.FavoriteBookshelves.Add(new Domain.Entities.Bookshelf
                {
                    BookshelfId = request.BookshelfId.ToString(),
                    UserId = request.UserId,
                    Title = bookshelf.Title
                });
                await _context.SaveChangesAsync();

                return ApiModel.Created();
            }
        }
    }
}
