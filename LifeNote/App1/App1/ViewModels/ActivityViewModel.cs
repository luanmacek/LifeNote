using Android.OS;
using App1.Model;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App1.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ActivityViewModel
    {
        public ObservableCollection<Activity> Activities { get; set; }
        public ActivityViewModel(Note note, bool newnote)
        {
            Activities = new ObservableCollection<Activity>();
            if (newnote)
            {
                Activity activity = new Activity() { Name = "Family", NoteId = note.Id, Selected = false };
                Activity activity2 = new Activity() { Name = "Study", NoteId = note.Id, Selected = false };
                Activity activity3 = new Activity() { Name = "Job", NoteId = note.Id, Selected = false };
                Activity activity4 = new Activity() { Name = "Friends", NoteId = note.Id, Selected = false };
                Activity activity6 = new Activity() { Name = "Food", NoteId = note.Id, Selected = false };
                Activity activity7 = new Activity() { Name = "Sport", NoteId = note.Id, Selected = false };
                Activity activity10 = new Activity() { Name = "Traveling", NoteId = note.Id, Selected = false };
                Activities.Add(activity);
                Activities.Add(activity2);
                Activities.Add(activity3);
                Activities.Add(activity4);
                Activities.Add(activity6);
                Activities.Add(activity7);
                Activities.Add(activity10);
                saveActivities();
            }
            load(note.Id);
        }
        public void saveActivities()
        {
            foreach (Activity a in Activities)
            {
                App.Database.SaveActivity(a);
            }
        }
        public async void load(int noteId)
        {
            try
            {
                Activities.Clear();
                List<Activity> result = await App.Database.GetActivitiesByNoteId(noteId);
                foreach (Activity a in result)
                    Activities.Add(a);
            }
            catch
            {

            }
        }


    }
}
