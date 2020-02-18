using App1.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.ViewModels
{
    public class ActivityViewModel
    {
        public List<Activity> Activities { get; set; }

        public ActivityViewModel()
        {
            Activities = new List<Activity>();
            Activities.Add(new Activity() { Name = "Family", Selected = false });
            //Activities.Add(new Activity() { Name = "Sport", Selected = false });
            //Activities.Add(new Activity() { Name = "Gaming", Selected = false });
            //Activities.Add(new Activity() { Name = "Relax", Selected = false });
            //Activities.Add(new Activity() { Name = "Food", Selected = false });
            //Activities.Add(new Activity() { Name = "Job", Selected = false });
            //Activities.Add(new Activity() { Name = "Study", Selected = false });
        }
    }
}
