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
using Elibrary.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Elibrary.Application.BookshelfsArea.Queries.GetBookshelfsList
{
    public class GetBookshelfsListQuery : IRequest<GetBookshelfsApiListModel>
    {
        public GetBookshelfsListQuery(string userId, BookshelfsOption bookshelfOptions)
        {
            BookshelfOptions = bookshelfOptions;
            UserId = userId;
        }

        public BookshelfsOption BookshelfOptions { get; set; }
        public string UserId { get; set; }

        public class GetBookshelfsQueryHandler : IRequestHandler<GetBookshelfsListQuery, GetBookshelfsApiListModel>
        {
            private readonly BooksService _booksService;
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetBookshelfsQueryHandler(
                IGoogleBooksServiceFactory googleBooksServiceFactory,
                IApplicationDbContext context,
                IMapper mapper)
            {
                _booksService = googleBooksServiceFactory.GetBooksService();
                _context = context;
                _mapper = mapper;
            }

            public async Task<GetBookshelfsApiListModel> Handle(GetBookshelfsListQuery request, CancellationToken cancellationToken)
            {
                GoogleData.Bookshelves googleBookshelves = await _booksService.Mylibrary.Bookshelves.List().ExecuteAsync();
                googleBookshelves.Items = googleBookshelves.Items.Where(x => x.Id.HasValue).ToList();

                if (googleBookshelves == null)
                {
                    return ApiModel.NotFound<GetBookshelfsApiListModel>();
                }

                switch (request.BookshelfOptions)
                {
                    case BookshelfsOption.Base:
                        googleBookshelves.Items = googleBookshelves.Items.Where(x => x.Id < 5).ToList();
                        break;
                    case BookshelfsOption.Custom:
                        googleBookshelves.Items = googleBookshelves.Items.Where(x => x.Id > 9).ToList();
                        break;
                    case BookshelfsOption.BaseAndCustom:
                        googleBookshelves.Items = googleBookshelves.Items.Where(x => x.Id < 5 || x.Id > 9).ToList();
                        break;
                    case BookshelfsOption.Others:
                        googleBookshelves.Items = googleBookshelves.Items.Where(x => x.Id >= 5 || x.Id <= 9).ToList();
                        break;
                    case BookshelfsOption.Favorites:
                        var favoriteBookshelves = await _context.FavoriteBookshelves
                            .Where(x => x.UserId == request.UserId)
                            .Select(x => x.BookshelfId)
                            .ToListAsync();
                        googleBookshelves.Items = googleBookshelves.Items
                            .Where(x => favoriteBookshelves.Contains(x.Id.ToString())).ToList();
                        break;
                    case BookshelfsOption.All:
                    default:
                        break;
                }

                IEnumerable<Bookshelf> bookshelfs = _mapper
                    .Map<IEnumerable<GoogleData.Bookshelf>, IEnumerable<Bookshelf>>(googleBookshelves.Items);

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
