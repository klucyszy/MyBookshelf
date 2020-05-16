using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Elibrary.Application.GoogleBooks.Interfaces;
using Google.Apis.Books.v1;
using GoogleData = Google.Apis.Books.v1.Data;
using MediatR;
using Elibrary.Application.Common.Models;
using Elibrary.Domain.Entities;
using System.Linq;
using System.Collections.Generic;
using Elibrary.Application.GoogleBooks.Models;

namespace Elibrary.Application.BooksArea.Queries.GetBooks
{
    public class GetAllUserVolumesListQuery : IRequest<GetAllUserVolumesApiModel>
    {
        public GetAllUserVolumesListQuery(GetBooksQueryRequest query, string userId)
        {
            Query = query;
            UserId = userId;
        }

        public GetBooksQueryRequest Query { get; set; }
        public string UserId { get; set; }

        public class GetAllUserVolumesListHandler : IRequestHandler<GetAllUserVolumesListQuery, GetAllUserVolumesApiModel>
        {
            private readonly BooksService _booksService;
            private readonly IMapper _mapper;

            public GetAllUserVolumesListHandler(
                IGoogleBooksServiceFactory googleBooksServiceFactory, 
                IMapper mapper)
            {
                _booksService = googleBooksServiceFactory.GetBooksService();
                _mapper = mapper;
            }

            public async Task<GetAllUserVolumesApiModel> Handle(
                GetAllUserVolumesListQuery request, 
                CancellationToken cancellationToken)
            {
                GoogleData.Bookshelves bookshelfsList = await _booksService.Mylibrary.Bookshelves.List().ExecuteAsync();


                IList<GoogleData.Bookshelf> bookshelfs = bookshelfsList.Items ?? new List<GoogleData.Bookshelf>();

                if (request.Query.BookshelfIds.Any())
                    bookshelfs = bookshelfs.Where(x => request.Query.BookshelfIds.Contains(x.Id ?? -1)).ToList();
                bookshelfs = bookshelfs.Where(x => x.VolumeCount > 0).ToList();

                if (bookshelfs?.Count == 0)
                {
                    return ApiModel.NotFound<GetAllUserVolumesApiModel>();
                }

                List<Volume> allVolumes = new List<Volume>();
                foreach (var bookshelf in bookshelfs)
                {
                    if (!bookshelf.Id.HasValue)
                    {
                        continue;
                    }

                    GoogleData.Volumes bookshelfVolumes = await _booksService.Mylibrary.Bookshelves.Volumes.List(bookshelf.Id.Value.ToString()).ExecuteAsync();

                    if (bookshelfVolumes?.Items == null)
                    {
                        continue;
                    }                    

                    foreach(var googleVolume in bookshelfVolumes.Items)
                    {
                        Volume volume = _mapper.Map<Volume>(googleVolume);
                        Volume volumeInList = allVolumes.FirstOrDefault(x => x.Id == volume.Id);

                        if (volumeInList != null)
                        {
                            volumeInList.UserBookshelfs.Add(new BookshelfBase { Id = bookshelf.Id, Title = bookshelf.Title});
                        }
                        else
                        {
                            volume.UserBookshelfs.Add(new BookshelfBase { Id = bookshelf.Id, Title = bookshelf.Title });
                            allVolumes.Add(volume);
                        }
                    }
                }

                return new GetAllUserVolumesApiModel(allVolumes);
            }
        }
    }
}
