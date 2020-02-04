using SQLite;
using System;
using System.Collections.Generic;
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
            _database.CreateTableAsync<Note>().Wait();
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

    }
}
