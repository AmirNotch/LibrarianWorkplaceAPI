using System.Linq;
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
    public class CreateReader
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Reader Reader { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Reader).SetValidator(new ReaderValidator());
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
                var readerFound = from reader in _context.Readers
                    where reader.Name.Contains(request.Reader.Name) &&
                          reader.DateOfBirth == request.Reader.DateOfBirth
                    select reader;

                var result = readerFound.ToList();
                
                if (result.Count != 0)
                {
                    return Result<Unit>.Failure("Reader with this Name and Date of Birth already Exist");
                }

                request.Reader.Exist = true;
                
                _context.Readers.Add(request.Reader);

                var resultFinal = await _context.SaveChangesAsync() > 0;

                if (!resultFinal)
                {
                    return Result<Unit>.Failure("Failed to create Reader"); 
                }
                
                return Result<Unit>.Success(Unit.Value); 
            }
        }
    }
}