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
        public GetAllUserVolumesListQuery(string userId)
        {
            UserId = userId;
        }

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
                GoogleData.Bookshelves allBookshelfs = await _booksService.Mylibrary.Bookshelves.List().ExecuteAsync();
                IList<GoogleData.Bookshelf> bookshelfs = allBookshelfs.Items?.Where(x => x.VolumeCount > 0).ToList();


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
                            volumeInList.UserBookshelfs.Add(bookshelf.Id.Value.ToString());
                        }
                        else
                        {
                            volume.UserBookshelfs.Add(bookshelf.Id.Value.ToString());
                            allVolumes.Add(volume);
                        }
                    }
                }

                return new GetAllUserVolumesApiModel(allVolumes);
            }
        }
    }
}
