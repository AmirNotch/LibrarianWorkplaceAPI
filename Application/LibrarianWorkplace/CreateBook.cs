using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Persistence;


namespace Application.LibrarianWorkplace
{
    public class CreateBook
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Book Book { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            
            public Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}