using DataGuard.Context;
using AttendanceBussiness.DbFirst;
using DataGuard.Models.BusinessDataModel;
using DataGuard.Utilities;
using LanguageResource;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc; 

namespace DataGuard.DALB
{
    /// <summary>
    /// DISCARD
    /// </summary>
    public class Organization
    {
        private static AttendanceBussiness.DbFirst.DataBaseContext dbContext = new AttendanceBussiness.DbFirst.DataBaseContext();
        private static string LanguageCode = LangUtilities.LanguageCode;
        public static string GetMainComCompanyName(string MainComId)
        {
            string CompanyName = string.Empty;

            if (!string.IsNullOrEmpty(MainComId))
            {
                AttendanceBussiness.DbFirst.MainCom mainCom = dbContext.MainCom.Find(MainComId);
                if (mainCom != null)
                {
                    CompanyName = LangUtilities.SwitchToSelectLang(mainCom.CompanyName, mainCom.CompanyAbbreviation);
                }
                return CompanyName;
            }
            else
            {
                return string.Empty;
            }
        }
        public static string GetContractorName(string ContractorId)
        {
            string ContractorName = string.Empty;

            if (!string.IsNullOrEmpty(ContractorId))
            {
                AttendanceBussiness.DbFirst.Contractor contractor = dbContext.Contractor.Find(ContractorId);
                if(contractor != null)
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

        public static string GetSiteName(string SiteId)
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

        public static string GetDepartmentName(string DepartmentId)
        {
            string departmentName = string.Empty;

            if (!string.IsNullOrEmpty(DepartmentId))
            {
                AttendanceBussiness.DbFirst.Department department = dbContext.Department.Find(DepartmentId);
                if (department != null)
                {
                    departmentName = LangUtilities.SwitchToSelectLang(department.DepartmentName, department.EnDepartmentName); ;
                }
                return departmentName;
            }
            else
            {
                return string.Empty;
            }
        }

        public static List<Department> GetDepartmentSwitchLangList(string MainComId)
        {
            AttendanceBussiness.DbFirst.Department department = new AttendanceBussiness.DbFirst.Department();
            List<Department> list =new List<Department>() ;
            
            foreach (var item in dbContext.Department.Where(s=>s.MainComId.Contains(MainComId)))
            { 
                department = new Department
                {
                    DepartmentId = item.DepartmentId
                    ,
                    IndustryId = item.IndustryId
                    ,
                    CompanyName = item.CompanyName
                    ,
                    EnDepartmentName =item.EnDepartmentName
                    ,
                    DepartmentAbbrName = item.DepartmentAbbrName
                    ,
                    DepartmentName = LangUtilities.SwitchToSelectLang(item.DepartmentName, item.EnDepartmentName)
                    ,
                    MainComId=item.MainComId
                };
                list.Add(department);
            }
            return list;
        }
        public static string GetPositionTitle(string PositionId)
        {
            string positionTitle = string.Empty;

            if (!string.IsNullOrEmpty(PositionId))
            {
                AttendanceBussiness.DbFirst.Position position = dbContext.Position.Find(PositionId);
                if (position != null)
                {
                    positionTitle = position.PositionTitle;
                }
                return positionTitle;
            }
            else
            {
                return string.Empty;
            }
        }
        public static string GetJobName(string JobId)
        {
            string jobName = string.Empty;

            if (!string.IsNullOrEmpty(JobId))
            {
                AttendanceBussiness.DbFirst.Job job = dbContext.Job.Find(JobId);
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
    public class ScheduleApplies
    {
        public int getDaysInMonth(int year,int month)
        {
            int days = DateTime.DaysInMonth(year, month);
            return days;
        }
        public int getDaysInMonth(int month)
        {
            int days = DateTime.DaysInMonth(DateTime.Now.Year, month);
            return days;
        }
        public int getDaysInThisMonth()
        {
            int days = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            return days;
        }
    }
}