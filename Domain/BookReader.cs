using System;

namespace Domain
{
    public class BookReader
    {
        public Guid BookGuid { get; set; }
        public Book Book { get; set; }
        public Guid ReaderGuid { get; set; }
        public Reader Reader { get; set; }
    }
}