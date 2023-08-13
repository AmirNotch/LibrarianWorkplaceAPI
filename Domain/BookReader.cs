using System;

namespace Domain
{
    public class BookReader
    {
        public Guid BookGuid { get; set; }
        public Book Book { get; set; }
        public Guid ReaderGuid { get; set; }
        public Reader Reader { get; set; }
        public string Event { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}