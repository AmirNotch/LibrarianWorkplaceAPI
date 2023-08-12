using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.LibrarianWorkplace
{

    public class DeleteBook
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
                var bookFound = await _context.BookReaders.FirstOrDefaultAsync(x => x.BookGuid == request.Id);

                if (!ReferenceEquals(bookFound, null))
                {
                    return Result<Unit>.Failure("Failed to delete Book");
                }
                
                var book = await _context.Books.FindAsync(request.Id);

                if (book == null)
                {
                    return null;
                }

                book.Exist = false;
                
                _context.Update(book);
                
                var result = await _context.SaveChangesAsync() > 0;
                
                if (!result)
                {
                    return Result<Unit>.Failure("Failed to delete the Book");
                }

                return Result<Unit>.Success(Unit.Value);
            }
        }

    }
}

