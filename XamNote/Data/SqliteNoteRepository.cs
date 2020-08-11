using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SQLite;
using XamNote.Models;

namespace XamNote.Data
{
    public class SqliteNoteRepository : INoteRepository
    {
        private SQLiteAsyncConnection _connection;

        public async Task AddOrUpdateNote(Note note)
        {
            if (note.Id != 0)
            {
                _ = await _connection.UpdateAsync(note);
            }
            else
            {
                _ = await _connection.InsertAsync(note);
            }
        }

        public Task<List<Note>> GetNotes()
            => _connection.Table<Note>().ToListAsync();

        public async Task Initialize()
        {
            if (_connection != null) return;

            _connection = new SQLiteAsyncConnection(
                Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "note.db3"));

            await _connection.CreateTableAsync<Note>();
        }
    }
}
