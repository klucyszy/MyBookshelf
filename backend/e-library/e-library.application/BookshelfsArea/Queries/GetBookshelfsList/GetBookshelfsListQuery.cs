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
using System.Runtime.Serialization;
using System.Linq;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Elibrary.Application.BookshelfsArea.Queries.GetBookshelfsList
{
    public class GetBookshelfsListQuery : IRequest<GetBookshelfsApiListModel>
    {
        public GetBookshelfsListQuery(BookshelfsOption bookshelfOptions)
        {
            BookshelfOptions = bookshelfOptions;
        }

        public BookshelfsOption BookshelfOptions { get; set; }

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

                if (googleBookshelfs == null)
                {
                    return ApiModel.NotFound<GetBookshelfsApiListModel>();
                }

                switch (request.BookshelfOptions)
                {
                    case BookshelfsOption.Base:
                        googleBookshelfs.Items = googleBookshelfs.Items.Where(x => x.Id < 5).ToList();
                        break;
                    case BookshelfsOption.Custom:
                        googleBookshelfs.Items = googleBookshelfs.Items.Where(x => x.Id > 9).ToList();
                        break;
                    case BookshelfsOption.BaseAndCustom:
                        googleBookshelfs.Items = googleBookshelfs.Items.Where(x => x.Id < 5 || x.Id > 9).ToList();
                        break;
                    case BookshelfsOption.Others:
                        googleBookshelfs.Items = googleBookshelfs.Items.Where(x => x.Id >= 5 || x.Id <= 9).ToList();
                        break;
                    case BookshelfsOption.Favorites:
                        googleBookshelfs.Items = new List<GoogleData.Bookshelf> { };
                        break;
                    case BookshelfsOption.All:
                    default:
                        break;
                }



                IEnumerable<Bookshelf> bookshelfs = _mapper
                    .Map<IEnumerable<GoogleData.Bookshelf>, IEnumerable<Bookshelf>>(googleBookshelfs.Items);

                return new GetBookshelfsApiListModel(bookshelfs);
            }
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum BookshelfsOption
        {
            [EnumMember(Value = "ALL")]
            All = 0,
            
            [EnumMember(Value = "BASE")]
            Base = 1,
            
            [EnumMember(Value = "CUSTOM")]
            Custom = 2,
            
            [EnumMember(Value = "BASEANDCUSTOM")]
            BaseAndCustom = 3,
            
            [EnumMember(Value = "OTHERS")]
            Others = 4,
            
            [EnumMember(Value = "FAVORITES")]
            Favorites = 5
        }

        //Bookshelfs:
        //    0, Favorites
        //    1, Purchased
        //    2, To read
        //    3, Reading now
        //    4, Have read
        //    5, Reviewed
        //    6, Recently viewed
        //    7, My Google eBooks
        //    8, Books for you
        //    9, Browsing history
        //    1001, ELibrary Test
    }
}
