using System.Threading;
using System.Threading.Tasks;
using Elibrary.Application.BooksApi;
using Google.Apis.Books.v1.Data;
using MediatR;

namespace Elibrary.Application.BooksArea.Queries.SearchBooks
{
    public class SearchBooksQuery : IRequest<SearchBooksViewModel>
    {
        public SearchBooksQuery(string userId, string query)
        {
            UserId = userId;
            Query = query;
        }

        public string UserId { get; set; }
        public string Query { get; set; }

        public class ISearchBooksQueryHandler : IRequestHandler<SearchBooksQuery, SearchBooksViewModel>
        {
            private readonly IGoogleBookApi _googleBookApi;

            public ISearchBooksQueryHandler(IGoogleBookApi googleBookApi)
            {
                _googleBookApi = googleBookApi;
            }

            public async Task<SearchBooksViewModel> Handle(SearchBooksQuery request, CancellationToken cancellationToken)
            {
                var viewModel = new SearchBooksViewModel();
                Volumes volumes = await _googleBookApi.GetVolumes(request.Query);

                foreach (var item in volumes.Items)
                {
                    viewModel.Results.Add(new GoogleVolume
                    {
                        Title = item?.VolumeInfo?.Title,
                        Subtitle = item?.VolumeInfo.Subtitle
                    });
                }

                return viewModel;
            }
        }


    }
}
