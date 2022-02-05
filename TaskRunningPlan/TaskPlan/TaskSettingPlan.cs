using AttendanceBussiness;
using AttendanceBussiness.DbFirst;
using System;
using System.Collections.Generic;
using System.Text;
 

namespace TaskRunningPlan
{
    public class TaskSettingPlan
    {
        private static DataBaseContext dbContext = new DataBaseContext();
          
        public static TaskSetting GetTaskSettingbyId(string TaskSettingId)
        {
            return dbContext.TaskSetting.Find(TaskSettingId); 
        }

        public static bool UpdateTaskStartDate(string TaskSettingId)
        {
            DateTime dateTime = DateTime.Now;
            TaskSetting taskSetting = TaskSettingPlan.GetTaskSettingbyId("CalcPeriodType_DAYLY_ScheduleAndShiftCalcJob");
            if(taskSetting.TaskStartDate.Date != DateTime.Now.Date)
            {
                TimeSpan timeSpan = taskSetting.TaskRuningStartTime;
                taskSetting.TaskStartDate = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
                dbContext.TaskSetting.Update(taskSetting);
                int result = dbContext.SaveChanges();
                return result > 0 ? true : false;
            }else
            {
                return false;
            }
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

        public static bool ThisMonthSceduleShouldRun()
        {
            string taskIdCorrespondingToSceduleDaily = TaskSettingConfig.CalcPeriodType_DAYLY_ScheduleAndShiftCalcJob;
            TaskSetting taskSetting = GetTaskSettingbyId(taskIdCorrespondingToSceduleDaily);
            TimeSpan tsRunningStart = taskSetting.TaskRuningStartTime;
            DateTime dtRunningStartDate = taskSetting.TaskStartDate;
            DateTime dtStartDatetime = new DateTime(dtRunningStartDate.Year, dtRunningStartDate.Month, dtRunningStartDate.Day,
                tsRunningStart.Hours, tsRunningStart.Minutes, tsRunningStart.Seconds, tsRunningStart.Milliseconds);
             
            if (dtStartDatetime > DateTime.Now)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool InitializeSceduleStartDate()
        {
            string taskIdCorrespondingToSceduleDaily = TaskSettingConfig.CalcPeriodType_DAYLY_ScheduleAndShiftCalcJob;
            TaskSetting taskSetting = GetTaskSettingbyId(taskIdCorrespondingToSceduleDaily);
            TimeSpan tsRunningStart = taskSetting.TaskRuningStartTime;
            DateTime dtRunningStartDate = taskSetting.TaskStartDate;
            DateTime dtStartDatetime = new DateTime(dtRunningStartDate.Year, dtRunningStartDate.Month, dtRunningStartDate.Day,
                tsRunningStart.Hours, tsRunningStart.Minutes, tsRunningStart.Seconds, tsRunningStart.Milliseconds);

            DateTime dtNextStartDatetime = dtStartDatetime.AddMonths(1);
            bool isUpdate = UpdateTaskStartDate(taskIdCorrespondingToSceduleDaily);

            if (isUpdate)
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
