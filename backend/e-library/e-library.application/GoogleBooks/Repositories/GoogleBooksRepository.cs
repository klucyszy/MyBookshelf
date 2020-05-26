using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Elibrary.Application.GoogleBooks.Constants;
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

        public async Task<IEnumerable<Volume>> GetBooks(List<int> bookshelfsIds)
        {
            var start = DateTime.Now;
            GoogleData.Bookshelves bookshelfsList = await _booksService.Mylibrary.Bookshelves.List().ExecuteAsync();
            IEnumerable<GoogleData.Bookshelf> bookshelves = bookshelfsList?.Items
                ?.Where(x => x.Id.HasValue && (x.Id.Value < 8 || x.Id.Value > 9));

            var allVolumes = new ConcurrentBag<Volume>();
            Parallel.ForEach(bookshelves, bookshelf =>
            {
                if (bookshelf.Id.HasValue)
                {
                    IList<Volume> bookshelfVolumes = GetBookshelfVolumes(bookshelf.Id.Value);
                    foreach(var item in bookshelfVolumes)
                    {
                        AddToBookshelfList(allVolumes, item, bookshelf.Id.Value, bookshelf.Title);
                    }
                }
            });

            IEnumerable<Volume> result = bookshelfsIds.Any()
                ? allVolumes.Where(x => x.UserBookshelfs.Any(us => bookshelfsIds.Contains(us.Id.Value)))
                : allVolumes;

            var end = DateTime.Now;
            var time = end.Subtract(start);
            System.Diagnostics.Debug.WriteLine($"The GetBooks request took: {time.TotalMilliseconds} ms.");

            return result;
        }

        private IList<Volume> GetBookshelfVolumes(int bookshelfId)
        {
            GoogleData.Volumes bookshelfVolumes;
            try
            {
                bookshelfVolumes = _booksService.Mylibrary.Bookshelves.Volumes.List(bookshelfId.ToString()).Execute();
            }
            catch (Exception ex)
            {
                return new List<Volume>();
            }


            if (bookshelfVolumes?.TotalItems == 0 && bookshelfVolumes.Items != null)
                return new List<Volume>();

            return _mapper.Map<IList<GoogleData.Volume>, IList<Volume>>(bookshelfVolumes.Items);
        }

        private void AddToBookshelfList(ConcurrentBag<Volume> list, Volume volume, int bookshelfId, string bookshelfTitle)
        {
            Volume itemInList = list.FirstOrDefault(x => x.Id == volume.Id);
            if(itemInList != null)
            {
                itemInList.AddToUserBookshelfs(bookshelfId, bookshelfTitle);
            }
            else
            {
                volume.AddToUserBookshelfs(bookshelfId, bookshelfTitle);
                list.Add(volume);
            }
        }

        private async Task<IEnumerable<BookshelfBase>> SelectBookshelfsAsync(IEnumerable<int> bookshelfsIds = null)
        {
            GoogleData.Bookshelves bookshelfsList = await _booksService.Mylibrary.Bookshelves.List().ExecuteAsync();
            IEnumerable<BookshelfBase> allUserBookshelfs = bookshelfsList?.Items
                ?.Where(x => x.Id.HasValue)
                ?.Select(x => new BookshelfBase(x.Id.Value, x.Title));

            IEnumerable<BookshelfBase> bookshelfs = bookshelfsIds?.Any() ?? false
                ? allUserBookshelfs.Where(x => bookshelfsIds.Contains(x.Id.Value)) // select only bookshelfs for filtered bookshelfIds
                : allUserBookshelfs.Where(x => CommonGoogleBookshelfs.BaseGoogleBookshelfIds.Contains(x.Id.Value) || x.Id.Value > 9); //select base and custom bookshelfs

            return bookshelfs;
        }

    }
}
