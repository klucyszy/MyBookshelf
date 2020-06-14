using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Elibrary.Application.Common.Interfaces;
using Elibrary.Application.Common.Models;
using Elibrary.Application.GoogleBooks.Interfaces;
using Google.Apis.Books.v1;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Elibrary.Application.BookshelfsArea.Command.DeleteFavoriteBookshelf
{
    public class DeleteFavoriteBookshelfCommand : IRequest<ApiModel>
    {
        public DeleteFavoriteBookshelfCommand(int bookshelfId, string userId)
        {
            BookshelfId = bookshelfId;
            UserId = userId;
        }

        public int BookshelfId { get; set; }
        public string UserId { get; set; }

        public class DeleteFavoriteBookshelfCommandHandler : IRequestHandler<DeleteFavoriteBookshelfCommand, ApiModel>
        {
            private readonly BooksService _booksService;
            private readonly IApplicationDbContext _context;

            public DeleteFavoriteBookshelfCommandHandler(
                IGoogleBooksServiceFactory googleBooksServiceFactory,
                IApplicationDbContext applicationDbContext)
            {
                _booksService = googleBooksServiceFactory.GetBooksService();
                _context = applicationDbContext;
            }

            public async Task<ApiModel> Handle(DeleteFavoriteBookshelfCommand request, CancellationToken cancellationToken)
            {
                var bookshelves = await _booksService.Mylibrary.Bookshelves.List().ExecuteAsync();
                var bookshelf = bookshelves?.Items?.FirstOrDefault(x => x.Id == request.BookshelfId);
                if (bookshelf == null)
                {
                    return ApiModel.NotFound();
                }

                Domain.Entities.Bookshelf item = await _context.FavoriteBookshelves
                    .FirstOrDefaultAsync(x => x.BookshelfId == request.BookshelfId.ToString() && x.UserId == request.UserId);
                if (item == null)
                {
                    return ApiModel.NotFound();
                }

                _context.FavoriteBookshelves.Remove(item);
                await _context.SaveChangesAsync();

                return ApiModel.Ok();
            }
        }
    }
}
