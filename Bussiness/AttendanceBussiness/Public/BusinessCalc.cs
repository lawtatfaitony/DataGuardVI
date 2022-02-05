using AttendanceBussiness.DbFirst;
using LanguageResource;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AttendanceBussiness
{
    public class Organization
    {  
        public static string GetMainComCompanyName(string MainComId)
        {
            using (DataBaseContext dbContext = new DataBaseContext())
            {
                string CompanyName = string.Empty;
                if (!string.IsNullOrEmpty(MainComId))
                {
                    AttendanceBussiness.DbFirst.MainCom mainCom = dbContext.MainCom.Find(MainComId);
                    if (mainCom != null)
                    {
                        CompanyName = ChineseStringUtility.ToAutoTraditional(mainCom.CompanyName);
                    }
                    return CompanyName;
                }
                else
                {
                    return string.Empty;
                }
            }
            
        }
        public static string GetContractorName(string ContractorId)
        {
            using (DataBaseContext dbContext = new DataBaseContext())
            {
                string ContractorName = string.Empty;

                if (!string.IsNullOrEmpty(ContractorId))
                {
                    AttendanceBussiness.DbFirst.Contractor contractor = dbContext.Contractor.Find(ContractorId);
                    if (contractor != null)
                    {
                        ContractorName = contractor.ContractorName;
                    }
                    return ContractorName;
                }
                else
                {
                    return string.Empty;
                }
            }
        } 
        public static string GetSiteName(string SiteId)
        {
            using (DataBaseContext dbContext = new DataBaseContext())
            {
                string SiteName = string.Empty;

                if (!string.IsNullOrEmpty(SiteId))
                {
                    AttendanceBussiness.DbFirst.Site site = dbContext.Site.Find(SiteId);
                    if (site != null)
                    {
                        SiteName = site.SiteName;
                    }
                    return SiteName;
                }
                else
                {
                    return string.Empty;
                }
            }
        } 
        public static string GetDepartmentName(string DepartmentId)
        {
            using (DataBaseContext dbContext = new DataBaseContext())
            {
                string DepartmentFullName = string.Empty;

                if (!string.IsNullOrEmpty(DepartmentId))
                {
                    AttendanceBussiness.DbFirst.Department department = dbContext.Department.Find(DepartmentId);
                    if (department != null)
                    {
                        DepartmentFullName = ChineseStringUtility.ToAutoTraditional((department.DepartmentFullName));
                    }
                    return DepartmentFullName;
                }
                else
                {
                    return string.Empty;
                }
            }
        } 
        public static List<Department> GetDepartmentSwitchLangList()
        {
            using (DataBaseContext dataBaseContext = new DataBaseContext())
            {
                AttendanceBussiness.DbFirst.Department department = new AttendanceBussiness.DbFirst.Department();
                List<Department> list = new List<Department>();
                var departments = dataBaseContext.Department;
                foreach (var item in departments)
                {
                    department = new Department
                    {
                        DepartmentId = item.DepartmentId,
                        IndustryId = item.IndustryId,
                        CompanyName = item.CompanyName,
                        EnDepartmentName = item.EnDepartmentName,
                        DepartmentAbbrName = item.DepartmentAbbrName,
                        DepartmentName = item.DepartmentFullName                       
                    };
                    list.Add(department);
                }
                return list;
            } 
        }
        public static string GetPositionTitle(string PositionId)
        {
            using (DataBaseContext dataBaseContext = new DataBaseContext())
            {
                string positionTitle = string.Empty;

                if (!string.IsNullOrEmpty(PositionId))
                {
                    AttendanceBussiness.DbFirst.Position position = dataBaseContext.Position.Find(PositionId);
                    if (position != null)
                    {
                        positionTitle = position.PositionFullName;
                    }
                    return positionTitle;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public static string GetJobName( string JobId)
        {
            using (DataBaseContext dataBaseContext = new DataBaseContext())
            {
                string jobName = string.Empty;

                if (!string.IsNullOrEmpty(JobId))
                {
                    AttendanceBussiness.DbFirst.Job job = dataBaseContext.Job.Find(JobId);
                    if (job != null)
                    {
                        jobName = job.JobName;
                    }
                    return jobName;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    } 
    public class ScheduleApplies
    {
        public int GetDaysInMonth(int year,int month)
        {
            int days = DateTime.DaysInMonth(year, month);
            return days;
        }
        public int GetDaysInMonth(int month)
        {
            int days = DateTime.DaysInMonth(DateTime.Now.Year, month);
            return days;
        }
        public int GetDaysInThisMonth()
        {
            int days = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            return days;
        }
    }
}