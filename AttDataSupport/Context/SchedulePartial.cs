using System;
using System.Collections.Generic; 

namespace AttendanceBussiness.DbFirst
{
    public partial class Schedule
    {
        public Schedule()
        { 
        }

        public virtual TimeSpan ScheduleWorkSpan
        {
            get
            {
                if(WorkEnd> WorkStart)
                {
                    TimeSpan timeSpan = WorkEnd.Subtract(WorkStart);
                    return timeSpan;
                }else
                {
                    WorkEnd.Add(new TimeSpan(1,0,0,0));
                    TimeSpan timeSpan = WorkStart.Subtract(WorkEnd);
                    return timeSpan;
                }
            }
        }
         
    }
}
