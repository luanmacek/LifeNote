using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace App1.Model
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;
        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            //_database.DropTableAsync<Note>().Wait();
            //_database.DropTableAsync<SideNote>().Wait();
            _database.CreateTableAsync<Note>().Wait();
            _database.CreateTableAsync<SideNote>().Wait();
        }
        public Task<int> SaveNoteAsync(Note note)
        {
            if (note.Id != 0)
            {
                return _database.UpdateAsync(note);
            }
            else
            {
                return _database.InsertAsync(note);
            }
        }

        public Task<Note> GetNoteAsync(string date)
        {
            return _database.Table<Note>()
                            .Where(i => i.Date == date)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveSideNoteAsync(SideNote sidenote)
        {
            if (sidenote.Id != 0)
            {
                return _database.UpdateAsync(sidenote);
            }
            else
            {
                return _database.InsertAsync(sidenote);
            }
        }

        public Task<List<SideNote>> GetSideNotesAsync()
        {
            return _database.Table<SideNote>().ToListAsync();
        }

        public Task<int> DeleteSideNoteAsync(SideNote sidenote)
        {
            return _database.DeleteAsync(sidenote);
        }

        public Task<SideNote> GetSideNoteById(int id)
        {
            return _database.GetAsync<SideNote>(id);
        }
    }
}
