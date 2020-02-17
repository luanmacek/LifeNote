using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Model
{
    public class Day
    {
        public string Name { get; set; }
        public int Points{ get; set; }

        public Day(string name, int points)
        {
            Name = name;
            Points = points;
        }
    }
}
