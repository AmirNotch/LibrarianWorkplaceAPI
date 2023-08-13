using System;
using System.Collections.Generic;

namespace Application.LibrarianWorkplace.DTO
{
    public class ReaderDtoForDetails
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateOfChange { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Exist { get; set; }
        public ICollection<BookDtoForDetails> Books { get; set; } 
    }
}