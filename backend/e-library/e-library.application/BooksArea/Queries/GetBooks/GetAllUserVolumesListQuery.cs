using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Elibrary.Application.GoogleBooks.Interfaces;
using MediatR;

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
            private readonly IGoogleBooksRepository _googleBooksRepository;

            public GetAllUserVolumesListHandler(
                IGoogleBooksRepository googleBooksRepository)
            {
                _googleBooksRepository = googleBooksRepository;
            }

            public async Task<GetAllUserVolumesApiModel> Handle(
                GetAllUserVolumesListQuery request, 
                CancellationToken cancellationToken)
            {
                IEnumerable<GoogleBooks.Models.Volume> volumes = 
                    await _googleBooksRepository.GetBooks(request.Query.BookshelfIds);

                return new GetAllUserVolumesApiModel(volumes);
            }
        }
    }
}
