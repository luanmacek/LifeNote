using App1.Model;
using PropertyChanged;
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace App1.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class StatisticsViewModel
    {
        public ObservableCollection<Note> Notes { get; set; }
        public ObservableCollection<Day> Days { get; set; }

        public StatisticsViewModel()
        {
            load_notes();
        }
        public async void load_notes()
        {
            List<Note> noteresults = await App.Database.GetNotesAsync();
            Notes = new ObservableCollection<Note>();
            foreach (Note sn in noteresults)
                Notes.Add(sn);

            List<Day> dayresults = await App.Database.GetDays();
            Days = new ObservableCollection<Day>();
            foreach (Day d in dayresults)
                Days.Add(d);
        }
    }
}
