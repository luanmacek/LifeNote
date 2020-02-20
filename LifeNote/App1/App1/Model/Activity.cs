using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace App1.Model
{
    [AddINotifyPropertyChangedInterface]
    public class Activity
    {
        public string Name { get; set; }

        public Activity(string name)
        {
            Name = name;
        }
    }
}
