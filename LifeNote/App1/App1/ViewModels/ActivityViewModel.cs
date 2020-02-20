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
        public ObservableCollection<Activity> SelectedItems { get; set; }
        public ActivityViewModel(bool Newnote, Note note)
        {
            Activities = new ObservableCollection<Activity>();
            Activities.Add(new Activity("Family"));
            Activities.Add(new Activity("Job"));
            Activities.Add(new Activity("Study"));
            Activities.Add(new Activity("Friends"));
            Activities.Add(new Activity("Relax"));
            Activities.Add(new Activity("Gaming"));
            SelectedItems = new ObservableCollection<Activity>();
            if (!Newnote)
            {
                load(note.Id);
            }

        }
        public async void load(int noteId)
        {
            Note note = await App.Database.GetNoteWithChildren(noteId);
            if(note.Activities != null)
            {
                foreach (Activity a in note.Activities)
                    SelectedItems.Add(a);
            }

        }

    }
}
