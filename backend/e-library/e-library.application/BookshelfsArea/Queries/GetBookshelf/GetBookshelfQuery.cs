using AutoMapper;
using Elibrary.Application.GoogleBooks.Interfaces;
using Google.Apis.Books.v1;
using GoogleData = Google.Apis.Books.v1.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Elibrary.Application.Common.Models;
using Elibrary.Application.GoogleBooks.Models;

namespace Elibrary.Application.BookshelfsArea.Queries.GetBookshelf
{
    public class GetBookshelfQuery : IRequest<GetBookshelfApiModel>
    {
        public GetBookshelfQuery(string bookshelfId)
        {
            BookshelfId = bookshelfId;
        }

        public string BookshelfId { get; set; }

        public class GetBookshelfQueryHandler : IRequestHandler<GetBookshelfQuery, GetBookshelfApiModel>
        {
            private readonly BooksService _booksService;
            private readonly IMapper _mapper;

            public GetBookshelfQueryHandler(
                IGoogleBooksServiceFactory googleBooksServiceFactory,
                IMapper mapper)
            {
                _booksService = googleBooksServiceFactory.GetBooksService();
                _mapper = mapper;
            }

            public async Task<GetBookshelfApiModel> Handle(GetBookshelfQuery request, CancellationToken cancellationToken)
            {
                GoogleData.Bookshelf googleBookshelf = await _booksService.Mylibrary.Bookshelves.Get(request.BookshelfId.ToString()).ExecuteAsync();

                if (googleBookshelf == null)
                {
                    return ApiModel.NotFound<GetBookshelfApiModel>();
                }

                Bookshelf bookshelf = _mapper.Map<Bookshelf>(googleBookshelf);
                
                return new GetBookshelfApiModel(bookshelf);
            }
        }
    }
}
