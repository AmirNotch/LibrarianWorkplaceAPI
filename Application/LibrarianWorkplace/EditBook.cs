﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.LibrarianWorkplace
{
    public class EditBook
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
            public Book Book { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var bookFound = await _context.BookReaders.FirstOrDefaultAsync(x => x.BookGuid == request.Id);

                if (!ReferenceEquals(bookFound, null))
                {
                    return Result<Unit>.Failure("Failed to update Book was given to readers");
                }

                var book = await _context.Books.FindAsync(request.Id);

                if (book == null)
                {
                    return null;
                }

                _mapper.Map(request.Book, book);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result)
                {
                    return Result<Unit>.Failure("Failed to update activity");
                }
                
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}