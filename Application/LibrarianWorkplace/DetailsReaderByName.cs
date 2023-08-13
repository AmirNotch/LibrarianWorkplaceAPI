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
    public class DetailsReaderByName
    {
        public class Query : IRequest<Result<ReaderDtoForDetails>>
        {
            public string Name { get; set; }
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
                    .FirstOrDefaultAsync(x => x.Name.Contains(request.Name));

                return Result<ReaderDtoForDetails>.Success(reader);
            }
        }
    }
}