using System;
using System.Collections.Generic;
using System.Text;

namespace MovieSchedule.Model
{
   public class Cinema
    {
        public int CinemaID { get; set; }
        public string CinemaName { get; set; }
        public int CinemasizeName { get; set; }
        public Dictionary<int,string> Halls { get; set; }

    }
}
