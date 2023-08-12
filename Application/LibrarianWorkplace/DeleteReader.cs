using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.LibrarianWorkplace
{
    public class DeleteReader
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var readerFound = await _context.BookReaders.FirstOrDefaultAsync(x => x.ReaderGuid == request.Id);

                if (!ReferenceEquals(readerFound, null))
                {
                    return Result<Unit>.Failure("Failed to detele Reader");
                }

                var read = await _context.Readers.FindAsync(request.Id);

                if (read == null)
                {
                    return null;
                }

                read.Exist = false;

                _context.Update(read);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result)
                {
                    return Result<Unit>.Failure("Failed to delete the Reader");
                }

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}