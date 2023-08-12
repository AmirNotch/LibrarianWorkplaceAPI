using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.LibrarianWorkplace.Params;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;


namespace Application.LibrarianWorkplace
{
    public class CreateBook
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Book Book { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Book).SetValidator(new BookValidator());
            }
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
                var bookFound = await _context.Books.FirstOrDefaultAsync(x => x.VendorCode == request.Book.VendorCode);

                if (!ReferenceEquals(bookFound, null))
                {
                    return Result<Unit>.Failure("Book with this VendorCode already Exist");
                }
                
                var book = new Book
                {
                    Name = request.Book.Name,
                    DateAdded = DateTime.UtcNow,
                    DateOfChange = DateTime.UtcNow,
                    Author = request.Book.Author,
                    VendorCode = request.Book.VendorCode,
                    YearOfPublishing = request.Book.YearOfPublishing,
                    NumberOfCopies = request.Book.NumberOfCopies,
                    Exist = true
                };

                _context.Books.Add(book);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result)
                {
                    return Result<Unit>.Failure("Failed to create book");
                }

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}