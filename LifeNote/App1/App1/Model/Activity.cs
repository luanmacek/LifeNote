using PropertyChanged;
using SQLite;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace App1.Model
{
    [AddINotifyPropertyChangedInterface]
    public class Activity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int NoteId { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set;}
    }
}
