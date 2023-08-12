using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.LibrarianWorkplace.DTO;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.LibrarianWorkplace
{
    public class DetailsReader
    {
        public class Query : IRequest<Result<ReaderDtoForDetails>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<ReaderDtoForDetails>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<Result<ReaderDtoForDetails>> Handle(Query request, CancellationToken cancellationToken)
            {
                var reader = await _context.Books
                    .ProjectTo<ReaderDtoForDetails>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);
                
                return Result<ReaderDtoForDetails>.Success(reader);
            }
        }
    }
}