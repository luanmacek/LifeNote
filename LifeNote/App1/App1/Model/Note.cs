using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App1.Model
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Date { get; set; }
        public string Content { get; set; }
        public int Points { get; set; }
    }
}