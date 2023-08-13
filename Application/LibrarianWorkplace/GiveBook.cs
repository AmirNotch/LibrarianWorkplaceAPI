using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.LibrarianWorkplace
{
    public class GiveBook
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid ReaderGuid { get; set; }
            public Guid BookGuid { get; set; }
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
                var reader = await _context.Readers.FirstOrDefaultAsync(x => x.Id == request.ReaderGuid);
                var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == request.BookGuid);

                var bookReader = new BookReader
                {
                    Book = book,
                    Reader = reader,
                    Event = "Вернута"
                };

                book.NumberOfCopies += 1;
                
                _context.BookReaders.Add(bookReader);
                _context.Books.Update(book);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result)
                {
                    return Result<Unit>.Failure("Failed to create Event");
                }
                
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}