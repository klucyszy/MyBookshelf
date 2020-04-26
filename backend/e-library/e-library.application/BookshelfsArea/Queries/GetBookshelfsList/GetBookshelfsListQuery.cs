using AutoMapper;
using Elibrary.Application.Common.Models;
using Elibrary.Application.GoogleBooks.Interfaces;
using Google.Apis.Books.v1;
using GoogleData = Google.Apis.Books.v1.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Elibrary.Application.GoogleBooks.Models;
using System.Collections.Generic;

namespace Elibrary.Application.BookshelfsArea.Queries.GetBookshelfsList
{
    public class GetBookshelfsListQuery : IRequest<GetBookshelfsApiListModel>
    {
        public class GetBookshelfsQueryHandler : IRequestHandler<GetBookshelfsListQuery, GetBookshelfsApiListModel>
        {
            private readonly BooksService _booksService;
            private readonly IMapper _mapper;

            public GetBookshelfsQueryHandler(
                IGoogleBooksServiceFactory googleBooksServiceFactory,
                IMapper mapper)
            {
                _booksService = googleBooksServiceFactory.GetBooksService();
                _mapper = mapper;
            }

            public async Task<GetBookshelfsApiListModel> Handle(GetBookshelfsListQuery request, CancellationToken cancellationToken)
            {
                GoogleData.Bookshelves googleBookshelfs = await _booksService.Mylibrary.Bookshelves.List().ExecuteAsync();

                if (googleBookshelfs == null || googleBookshelfs.Items?.Count == 0)
                {
                    return ApiModel.NotFound<GetBookshelfsApiListModel>();
                }

                IEnumerable<Bookshelf> bookshelfs = _mapper
                    .Map<IEnumerable<GoogleData.Bookshelf>, IEnumerable<Bookshelf>>(googleBookshelfs.Items);

                return new GetBookshelfsApiListModel(bookshelfs);
            }
        }
    }
}
