using System;

namespace Application.LibrarianWorkplace.DTO
{
    public class BookDtoForDetails
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateOfChange { get; set; }
        public string Author { get; set; }
        public string VendorCode { get; set; }
        public DateTime YearOfPublishing { get; set; }
        public int NumberOfCopies { get; set; }
        public bool Exist { get; set; }
        public string Event { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
