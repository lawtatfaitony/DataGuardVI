using System;
using System.Collections.Generic;
using System.Text;
using AttendanceBussiness.DbFirst;

namespace AttendanceBussiness
{
    public class TaskSettingPlan
    {
        private static AttendanceBussiness.DbFirst.DataBaseContext dbContext = new AttendanceBussiness.DbFirst.DataBaseContext();
          
        public static TaskSetting GetTaskSettingbyId(string TaskSettingId)
        {
            return dbContext.TaskSetting.Find(TaskSettingId); 
        }

        public static bool UpdTaskSettingTimesOfTaskRunned(string TaskSettingId, int TimesOfTaskRunned=1)
        {
            TaskSetting taskSetting = dbContext.TaskSetting.Find(TaskSettingId);
            taskSetting.TimesOfTaskRunning += TimesOfTaskRunned;
            dbContext.TaskSetting.Update(taskSetting);
            int result = dbContext.SaveChanges();
            if(result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsRunnedByTaskSettingBusiness(string TaskSettingId,DateTime RunnedTime)
        {
            TaskSetting taskSetting = dbContext.TaskSetting.Find(TaskSettingId);

            TimeSpan RunnedTimeSpan = RunnedTime.TimeOfDay;

            if (RunnedTime < taskSetting.TaskStartDate )
            {
                return false;
            }
            if (RunnedTimeSpan>=taskSetting.TaskRuningStartTime && RunnedTimeSpan < taskSetting.TaskRuningEndTime)
            {
                return true;
            }else
            {
                return false;
            }
        } 
        public static bool IsRunnedByTaskSettingBusiness(string TaskSettingId, DateTime RunnedTime, int TimesOfTaskRunned)
        {
            TaskSetting taskSetting = dbContext.TaskSetting.Find(TaskSettingId);

            TimeSpan RunnedTimeSpan = RunnedTime.TimeOfDay;

            if (RunnedTime < taskSetting.TaskStartDate)
            {
                return false;
            }

            if (TimesOfTaskRunned > taskSetting.TimesOfTaskRunning)
            {
                return false;
            }

            if (RunnedTimeSpan >= taskSetting.TaskRuningStartTime && RunnedTimeSpan < taskSetting.TaskRuningEndTime)
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
        public static bool IsOnceByTaskSettingBusiness(string TaskSettingId)
        {
            TaskSetting taskSetting = dbContext.TaskSetting.Find(TaskSettingId); 
            
            if (taskSetting.TimesOfTaskRunning >=1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
