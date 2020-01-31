using System;
using System.Collections.Generic;
using System.Text;

namespace MovieSchedule.Model
{
   public  class Schedule
    {
        public int ScheduleId { get; set; }
        public Movie Movie{ get; set; }
        public string Dimention { get; set; }
    }
}
