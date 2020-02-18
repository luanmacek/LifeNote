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

        public ActivityViewModel()
        {
            load();
        }

        async void load()
        {
            List<Activity> activityresults = await App.Database.GetActivities();
            Activities = new ObservableCollection<Activity>();
            foreach (Activity a in activityresults)
                Activities.Add(a);
        }
    }
}
