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
        public int NumberOfEvent { get; set; }
        public DateTime DateTimeOfEvent { get; set; }
        public ICollection<BookReader> Books { get; set; } = new List<BookReader>();
    }
}