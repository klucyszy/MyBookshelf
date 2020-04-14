using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Elibrary.Application.Common.Interfaces;
using MediatR;

namespace Elibrary.Application.BooksArea.Queries.GetBooks
{
    public class GetBooksQuery : IRequest<GetBooksViewModel>
    {
        public GetBooksQuery(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }

        public class GetBooksHandler : IRequestHandler<GetBooksQuery, GetBooksViewModel>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetBooksHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public Task<GetBooksViewModel> Handle(
                GetBooksQuery request, 
                CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
