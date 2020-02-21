using App1.Model;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace App1.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class SideNoteViewModel
    {
        public ObservableCollection<SideNote> sidenotes { get; set; }
        public ObservableCollection<Day> days { get; set; }
        public SideNoteViewModel()
        {
            sidenotes = new ObservableCollection<SideNote>();
            load();
        }

        async void load()
        {
            //load sidenotes
            List<SideNote> results = await App.Database.GetSideNotesAsync();
            foreach (SideNote sn in results)
                sidenotes.Add(sn);
        }
    }
}
