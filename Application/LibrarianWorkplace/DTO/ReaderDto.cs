using System;

namespace Application.LibrarianWorkplace.DTO
{
    public class ReaderDto
    {
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateOfChange { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int NumberOfEvent { get; set; }
        public DateTime DateTimeOfEvent { get; set; }
    }
}