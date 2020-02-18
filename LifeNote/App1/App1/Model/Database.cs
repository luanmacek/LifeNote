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
            _database.DropTableAsync<Note>().Wait();
            _database.DropTableAsync<SideNote>().Wait();
            _database.CreateTableAsync<Note>().Wait();
            _database.CreateTableAsync<SideNote>().Wait();
        }
        public Task<List<Note>> GetNotesAsync()
        {
            return _database.Table<Note>().ToListAsync();
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

        public async Task<int> GetDayPoints(string day)
        {
            List<Note> notes = await _database.Table<Note>().Where(i => i.Day == day).ToListAsync();
            int points = 0;
            foreach (Note n in notes)
                points = points + n.Points;

            return points;
        }

        public async Task<List<Day>> GetDays()
        {
            Day monday = new Day("Monday", await GetDayPoints("Monday"));
            Day tuesday = new Day("Tuesday", await GetDayPoints("Tuesday"));
            Day wednesday = new Day("Wednesday", await GetDayPoints("Wednesday"));
            Day thursday = new Day("Thursday", await GetDayPoints("Thursday"));
            Day friday = new Day("Friday", await GetDayPoints("Friday"));
            Day saturday = new Day("Saturday", await GetDayPoints("Saturday"));
            Day sunday = new Day("Sunday", await GetDayPoints("Sunday"));

            List<Day> days = new List<Day> { monday, tuesday, wednesday, thursday, friday, saturday, sunday };

            return days;
        }

        public async Task<List<Activity>> GetActivities()
        {


            Activity activity = new Activity("Family");
            Activity activity2 = new Activity("Sport");
            Activity activity3 = new Activity("Relax");
            Activity activity4 = new Activity("Gaming");
            Activity activity5 = new Activity("Food");
            Activity activity6 = new Activity("Job");

            List<Activity> activities = new List<Activity> { activity, activity2, activity3, activity4, activity5, activity6};

            return activities;
        }
    }
}
