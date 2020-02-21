using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions;
using SQLiteNetExtensionsAsync.Extensions;

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
            //_database.DropTableAsync<Activity>().Wait();
            _database.CreateTableAsync<Note>().Wait();
            _database.CreateTableAsync<SideNote>().Wait();
            _database.CreateTableAsync<Activity>().Wait();
        }
        public Task<List<Note>> GetNotesAsync()
        {
            return _database.Table<Note>().ToListAsync();
        }
        public async Task<int> SaveNoteAsync(Note note)
        {
            if (note.Id != 0)
            {
                await _database.UpdateWithChildrenAsync(note);
            }
            else
            {
                await _database.InsertWithChildrenAsync(note, true);
            }
            return note.Id;
        }

        public Task<Note> GetNoteByDateAsync(string date)
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

        public async Task<int> GetDayPoints(string day)
        {
            List<Note> notes = await _database.Table<Note>().Where(i => i.Day == day).ToListAsync();
            int points = 0;
            foreach (Note n in notes)
                points = points + n.Points;

            return points;
        }

        public Task<Note> GetNoteWithChildren(int id)
        {
            return _database.GetWithChildrenAsync<Note>(id);
        }

        public Task<int> SaveActivity(Activity a)
        {
            if (a.Id != 0)
            {
                return _database.UpdateAsync(a);
            }
            else
            {
                return _database.InsertAsync(a);
            }
        }

        public async Task<List<Activity>> GetActivitiesByNoteId(int noteId)
        {
            List<Activity> activities = await _database.Table<Activity>().Where(i => i.NoteId == noteId).ToListAsync();   
            return activities;
        }

        public async Task<List<Activity>> GetActivities()
        {
            List<Activity> activities = await _database.Table<Activity>().ToListAsync();
            return activities;
        }
    }
}
