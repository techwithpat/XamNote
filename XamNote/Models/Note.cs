using System;
using SQLite;

namespace XamNote.Models
{
    public class Note
    {
        public Note()
        {
            CreateAt = DateTime.Now;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
