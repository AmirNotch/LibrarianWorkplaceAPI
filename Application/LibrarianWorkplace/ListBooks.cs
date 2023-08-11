using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.LibrarianWorkplace.DTO;
using Application.LibrarianWorkplace.Params;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Persistence;

namespace Application.LibrarianWorkplace
{
    public class ListBooks
    {
        public class Query : IRequest<Result<PagedList<BookDto>>>
        {
            public BookParams Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PagedList<BookDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            
            public async Task<Result<PagedList<BookDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.Books
                    .OrderBy(d => d.YearOfPublishing)
                    .ProjectTo<BookDto>(_mapper.ConfigurationProvider)
                    .AsQueryable();

                return Result<PagedList<BookDto>>.Success(
                    await PagedList<BookDto>.CreateAsync(query, request.Params.PageNumber,
                        request.Params.PageSize));
            }
        }
    }
}