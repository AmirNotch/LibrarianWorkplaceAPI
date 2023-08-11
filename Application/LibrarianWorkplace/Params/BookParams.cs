using System;
using Application.Core;

namespace Application.LibrarianWorkplace.Params
{
    public class BookParams : PagingParams
    {
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
    }
}