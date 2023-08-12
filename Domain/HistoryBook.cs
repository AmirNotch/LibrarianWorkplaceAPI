using System;

namespace Domain
{
    public class HistoryBook
    {
        public Guid Id { get; set; }
        public string Event { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Book Book { get; set; }
        public Reader Reader { get; set; }
    }
}