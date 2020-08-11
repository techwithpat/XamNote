using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamNote.Models;

namespace XamNote.Data
{
    public interface INoteRepository
    {
        Task Initialize();
        Task<List<Note>> GetNotes();
        Task AddOrUpdateNote(Note note);
    }
}
