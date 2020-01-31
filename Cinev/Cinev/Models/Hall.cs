using System;
using System.Collections.Generic;
using System.Text;

namespace MovieSchedule.Model
{
   public class Hall
    {
        public int HallId { get; set; }
        public string HallName { get; set; }
      public List<Schedule> Schedules { get; set; }
    }
}
