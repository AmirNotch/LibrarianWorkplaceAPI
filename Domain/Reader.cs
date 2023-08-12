using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class Reader
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateOfChange { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Exist { get; set; }
        public ICollection<BookReader> Books { get; set; } = new List<BookReader>();
        public ICollection<HistoryBook> HistoryBooks { get; set; }
    }
}