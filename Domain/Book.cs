using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateOfChange { get; set; }
        public string Author { get; set; }
        public string VendorCode { get; set; }
        public DateTime YearOfPublishing { get; set; }
        public int NumberOfCopies { get; set; }
        public int NumberOfEvent { get; set; }
        public DateTime DateTimeOfEvent { get; set; }
        public ICollection<BookReader> Readers { get; set; } = new List<BookReader>();
    }
}