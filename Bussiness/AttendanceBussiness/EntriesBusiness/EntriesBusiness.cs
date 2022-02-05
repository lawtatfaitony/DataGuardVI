using AttendanceBussiness.DbFirst;
using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;

namespace AttendanceBussiness.EntriesBusiness
{
    public class Entries
    {
        private static DataBaseContext dbContext = new DataBaseContext();

        public static bool AddOrUpdate(AttendanceLog attendanceLog)
        {
            attendanceLog.HmacHash = HamcAttendanceLog(attendanceLog);
            bool existRecord = dbContext.AttendanceLog.Find(attendanceLog.AttendanceLogId) == null;
            if (existRecord)
            {
                try
                {
                    dbContext.AttendanceLog.Add(attendanceLog);
                    int result = dbContext.SaveChanges();
                    return result > 0;
                }
                catch
                {
                    return false; 
                }
            }
            return true;
        } 

        public static bool AddEmployeeRequied(string MainComId, string EmployeeId ,int gender,DateTime Birthday, DateTime EnrollmentDate, DateTime CreatedDate,bool IsBlock)
        {
            Employee employee = dbContext.Employee.Find(EmployeeId);
            string CompanyName = dbContext.MainCom.Find(MainComId).CompanyName;
            if (employee == null)
            {
                employee = new Employee
                {
                    EmployeeId = EmployeeId,
                    The3rdPartyEmployeeId = "",
                    ParentUserId = "",
                    UserIcon = "",
                    FirstName = "",
                    LastName = "",
                    PhoneNumber = "",
                    Email = "",
                    MainComId = MainComId,
                    CompanyName = CompanyName,
                    ContractorId = "",
                    ContractorName = "",
                    SiteId = "",
                    SiteName = "",
                    DepartmentId = "",
                    DepartmentName = "",
                    JobId = "",
                    JobName = "",
                    PositionId = "",
                    PositionTitle= "",
                    AccessCardId = "",
                    CnName = EmployeeId,
                    Gender = gender,
                    Birthday = Birthday,
                    EnrollmentDate = EnrollmentDate,
                    CreatedDate = CreatedDate,
                    LeaveDate = CreatedDate,
                    Remarks = "",
                    OperatedDate = DateTime.Now,
                    OperatedUserName = "",
                    IsBlock = IsBlock
                };

                int res = 0;
                try
                {
                    dbContext.Employee.Add(employee);
                    res = dbContext.SaveChanges();
                }
                catch (DbException ex)
                {
                    string LoggerLine = string.Format("[ERROR] [SUCCESS = FALSE] FUNC::AddEmployeeRequied {0}", ex.Message);
                    PublicGlobal.ConsoleWriteline(LoggerLine);
                }
               
                if (res > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static string HamcAttendanceLog(AttendanceLog a)
        {
            string CnName = CommonBase.StringToBase64(a.CnName);
            string DepartmentName = CommonBase.StringToBase64(a.DepartmentName);
            string SiteName = CommonBase.StringToBase64(a.SiteName);
            string PositionTitle = CommonBase.StringToBase64(a.PositionTitle);
            string ContractorName = CommonBase.StringToBase64(a.ContractorName);
            string AccesscardId = CommonBase.StringToBase64(a.AccesscardId);

            string HamcContent = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}]", a.AccesscardId,a.EmployeeId.Trim(), a.DeviceId, a.OccurDateTime, a.CratedDateTime.Ticks, CnName
                ,DepartmentName, SiteName, PositionTitle, ContractorName, AccesscardId);

            string HmacHash = CommonBase.HMACSHA1Encode(HamcContent);

            return HmacHash;
        }


        public static string HcEmployee(Employee E)
        {
            string CnName = CommonBase.StringToBase64(E.CnName);
            string DepartmentName = CommonBase.StringToBase64(E.DepartmentName);
            string SiteName = CommonBase.StringToBase64(E.SiteName);
            string PositionTitle = CommonBase.StringToBase64(E.PositionTitle);
            string ContractorName = CommonBase.StringToBase64(E.ContractorName);
            string AccesscardId = CommonBase.StringToBase64(E.AccessCardId);
            string jobId = CommonBase.StringToBase64(E.JobId);
            string jobName = CommonBase.StringToBase64(E.JobName);
            string positionId = CommonBase.StringToBase64(E.PositionId);
            string positionTitle = CommonBase.StringToBase64(E.PositionTitle);
            string enName = CommonBase.StringToBase64(E.FirstName+E.LastName);

            string strContent = string.Format("[{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}]", E.AccessCardId, E.EmployeeId, E.DepartmentId, E.EnrollmentDate.Ticks, E.CreatedDate.Ticks, CnName
                , DepartmentName, SiteName, PositionTitle, ContractorName, AccesscardId, jobId, jobName, positionId, positionTitle, enName);

            string str = CommonBase.HMACSHA1Encode(strContent);

            return str;
        }
    }
}
