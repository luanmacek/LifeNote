using App1.Model;
using LifeNote.Model;
using PropertyChanged;
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace App1.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class StatisticsViewModel
    {
        public List<Day> Days { get; set; }
        public ObservableCollection<ActivityCounter> ActivityCounters {get;set;}

        public StatisticsViewModel()
        {
            ActivityCounters = new ObservableCollection<ActivityCounter>();
            load();
        }
        public async void load()
        {

            Day monday = new Day("Monday", await App.Database.GetDayPoints("Monday"));
            Day tuesday = new Day("Tuesday", await App.Database.GetDayPoints("Tuesday"));
            Day wednesday = new Day("Wednesday", await App.Database.GetDayPoints("Wednesday"));
            Day thursday = new Day("Thursday", await App.Database.GetDayPoints("Thursday"));
            Day friday = new Day("Friday", await App.Database.GetDayPoints("Friday"));
            Day saturday = new Day("Saturday", await App.Database.GetDayPoints("Saturday"));
            Day sunday = new Day("Sunday", await App.Database.GetDayPoints("Sunday"));

            Days = new List<Day> { monday, tuesday, wednesday, thursday, friday, saturday, sunday };

            List<Activity> result = await App.Database.GetActivities();



            foreach(Activity a in result)
            {
                if (!ActivityCounters.Any(i => i.Name == a.Name))
                {
                    ActivityCounter newac = new ActivityCounter(a.Name);
                    ActivityCounters.Add(newac);      

                }
            }

            foreach (ActivityCounter ac in ActivityCounters)
            {
                ac.Counter = result.Where(item => item.Selected).Where(item => item.Name == ac.Name).Count();
            }

        }
        
    }
}
