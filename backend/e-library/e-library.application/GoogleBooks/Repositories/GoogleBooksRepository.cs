using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Elibrary.Application.GoogleBooks.Interfaces;
using Elibrary.Application.GoogleBooks.Models;
using Google.Apis.Books.v1;
using GoogleData = Google.Apis.Books.v1.Data;

namespace Elibrary.Application.GoogleBooks.Repositories
{
    public class GoogleBooksRepository : IGoogleBooksRepository
    {
        private readonly BooksService _booksService;
        private readonly IMapper _mapper;

        public GoogleBooksRepository(
            IGoogleBooksServiceFactory googleBooksServiceFactory,
            IMapper mapper)
        {
            _booksService = googleBooksServiceFactory.GetBooksService();
            _mapper = mapper;
        }

        public async Task<IEnumerable<Volume>> GetBooks(IEnumerable<int> bookshelfsIds)
        {
            var start = DateTime.Now;

            GoogleData.Bookshelves bookshelfsList = await _booksService.Mylibrary.Bookshelves.List().ExecuteAsync();

            IList<GoogleData.Bookshelf> bookshelfs = bookshelfsList.Items ?? new List<GoogleData.Bookshelf>();

            bookshelfs = bookshelfsIds.Any()
                ? bookshelfs.Where(x => bookshelfsIds.Contains(x.Id ?? -1) && x.VolumeCount > 0).ToList()
                : bookshelfs = bookshelfs.Where(x => x.VolumeCount > 0).ToList();

            List<Volume> allVolumes = new List<Volume>();
            foreach (var bookshelf in bookshelfs)
            {
                if (!bookshelf.Id.HasValue)
                {
                    continue;
                }

                GoogleData.Volumes bookshelfVolumes = await _booksService.Mylibrary.Bookshelves.Volumes.List(bookshelf.Id.Value.ToString()).ExecuteAsync();

                if (bookshelfVolumes?.TotalItems == 0)
                {
                    continue;
                }

                foreach (var googleVolume in bookshelfVolumes.Items)
                {
                    Volume volume = _mapper.Map<Volume>(googleVolume);
                    Volume volumeInList = allVolumes.FirstOrDefault(x => x.Id == volume.Id);

                    if (volumeInList != null)
                    {
                        volumeInList.UserBookshelfs.Add(new BookshelfBase { Id = bookshelf.Id, Title = bookshelf.Title });
                    }
                    else
                    {
                        volume.UserBookshelfs.Add(new BookshelfBase { Id = bookshelf.Id, Title = bookshelf.Title });
                        allVolumes.Add(volume);
                    }
                }
            }

            var end = DateTime.Now;
            var time = end.Subtract(start);

            return allVolumes;
        }
    }
}
