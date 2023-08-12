using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.LibrarianWorkplace.DTO;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.LibrarianWorkplace
{
    public class DetailsBook
    {
        public class Query : IRequest<Result<BookDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<BookDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            
            public async Task<Result<BookDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var book = await _context.Books
                    .ProjectTo<BookDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                return Result<BookDto>.Success(book);
            }
        }
    }
}