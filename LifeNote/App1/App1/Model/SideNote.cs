using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Model
{
    public class SideNote
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
