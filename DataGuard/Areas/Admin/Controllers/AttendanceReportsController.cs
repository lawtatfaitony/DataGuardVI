using AttendanceBussiness;
using AttendanceBussiness.AttendanceByDay;
using AttendanceBussiness.AttendanceByPeriod;
using AttendanceBussiness.AttendanceSchedule;
using AttendanceBussiness.DbFirst;
using AttendanceBussiness.Public;
using AttendanceBussiness.ScheduleAndShift;
using AttendanceBussiness.ScheduleBusiness;
using Common;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DataGuard.App_Start;
using DataGuard.Context;
using LanguageResource;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using X.PagedList;
using static AttendanceBussiness.ShiftBusiness;

namespace DataGuard.Areas.Admin.Controllers
{
    [Authorize(Roles = "SystemAdmin,Admin,MainComOperator,LRO")]
    public class AttendanceReportsController : BaseController
    {
        public ActionResult ScheduleIndex(string ContractorId, string SiteId, string DepartmentId, string PositionId, string JobId,
           string sortOrder, string searchString, string scheduleDateRange, string currentFilter, int? page)
        {
            ModalDialog modalDialog = new ModalDialog();
            string MainComId = !string.IsNullOrEmpty(WebCookie.MainComId) ? WebCookie.MainComId : dbContext.AspNetUsers.Find(User.Identity.GetUserId()).MainComId;
            string IndustryId = WebCookie.IndustryId;

            this.ContractorIdDropDownList(ContractorId);
            SiteIdDropDownList(SiteId);
            DepartmentIdDropDownList(DepartmentId);
            PositionIdDropDownList(IndustryId, PositionId);
            IndustryIdDropDownList(IndustryId, JobId);
            JobIdDropDownList(IndustryId, JobId);
            //---------------------------------------------------------------------
            DateTime dt = DateTime.Now;
            if (!string.IsNullOrEmpty(scheduleDateRange))
            {
                scheduleDateRange = this.Server.UrlDecode(scheduleDateRange);
                ViewBag.CurrentScheduleDateRange = scheduleDateRange;
            }
            else
            {
                scheduleDateRange = string.Format("{0:yyyy-MM-ddTHH:mm}-{1:yyyy-MM-ddTHH:mm}", dt, dt.AddDays(30));
                ViewBag.CurrentScheduleDateRange = scheduleDateRange;
            }
            DateTimeRangeObj dateTimeRangeObj = new DateTimeRangeObj();
            dateTimeRangeObj = CommonBase.DateTimeRangeParse(scheduleDateRange);

            if (dateTimeRangeObj.Start == dateTimeRangeObj.End)
            {
                dateTimeRangeObj.End = dateTimeRangeObj.End.AddDays(30);
            }
            if (String.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "date_desc";
            }
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.CurrentContractorId = ContractorId;
            ViewBag.CurrentSiteId = SiteId;
            ViewBag.CurrentDepartmentId = DepartmentId;
            ViewBag.CurrentPositionId = PositionId;
            ViewBag.CurrentJobId = JobId;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            ScheduleSearchingResult scheduleSearchingResult = ScheduleUtilize.ScheduleSearching( MainComId, ContractorId, SiteId, DepartmentId, PositionId, JobId, sortOrder, searchString, dateTimeRangeObj);
            ViewBag.monthHeaders = scheduleSearchingResult.monthHeaders;
            ViewBag.ShiftList = scheduleSearchingResult.ShiftList.Count > 0 ? scheduleSearchingResult.ShiftList : null;
            int pageSize = 100;
            int pageNumber = (page ?? 1);
            return View("ScheduleIndex31", scheduleSearchingResult.ListScheduleMonth31.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult ScheduleChartSearching(string ContractorId, string SiteId, string DepartmentId, string PositionId, string JobId,
          string sortOrder, string searchString, string scheduleDateRange, string currentFilter, int? page)
        {
            GlobalConfig publicGlobalConfig = new GlobalConfig();
            //render json 
            //---------------------------------------------------------------------------------------------------------------------
            ModalDialog modalDialog = new ModalDialog();
            string MainComId = !string.IsNullOrEmpty(WebCookie.MainComId) ? WebCookie.MainComId : dbContext.AspNetUsers.Find(User.Identity.GetUserId()).MainComId;
            string IndustryId = WebCookie.IndustryId;
            #region Droplist
            ContractorIdDropDownList(ContractorId);
            SiteIdDropDownList(SiteId);
            DepartmentIdDropDownList(DepartmentId);
            PositionIdDropDownList(IndustryId, PositionId);
            IndustryIdDropDownList(IndustryId, JobId);
            JobIdDropDownList(IndustryId, JobId);
            #endregion

            #region params
            //---------------------------------------------------------------------
            DateTime dt = DateTime.Now;
            long dtLong = DateTimeHelp.ConvertDateTimeToLong(dt);
            long scheduleDateStart = dtLong;
            long scheduleDateEnd = dtLong;
            if (!string.IsNullOrEmpty(scheduleDateRange))
            {
                scheduleDateRange = this.Server.UrlDecode(scheduleDateRange);
                DateTimeRangeObj dateTimeRangeObj = new DateTimeRangeObj();
                dateTimeRangeObj = CommonBase.DateTimeRangeParse(scheduleDateRange);
                scheduleDateStart = DateTimeHelp.ConvertDateTimeToLong(dateTimeRangeObj.Start);
                scheduleDateEnd = DateTimeHelp.ConvertDateTimeToLong(dateTimeRangeObj.End);

                ViewBag.CurrentScheduleDateRange = string.Format("{0:yyyy-MM-ddTHH:mm}-{1:yyyy-MM-ddTHH:mm}", dateTimeRangeObj.Start, dateTimeRangeObj.End);
            }
            else
            {
                ViewBag.CurrentScheduleDateRange = string.Format("{0:yyyy-MM-ddTHH:mm}-{1:yyyy-MM-ddTHH:mm}", dt, dt.AddDays(30));
                scheduleDateEnd = dt.AddDays(30).Ticks;
            }
            ViewBag.CurrentScheduleDateRange = string.Format("{0:yyyy-MM-ddTHH:mm}-{1:yyyy-MM-ddTHH:mm}", dt, dt.AddDays(30)); //================
            if (scheduleDateStart == scheduleDateEnd)
            {
                scheduleDateEnd = dt.AddDays(30).Ticks;
            }

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            #endregion

            //--------------------------------------------------------------------------------------------------------------------------------------
            #region currentQuery
            var schedules = from s in dbContext.Schedule.Where(c => c.MainComId == MainComId && c.ScheduleDate >= new DateTime(scheduleDateStart) && c.ScheduleDate <= new DateTime(scheduleDateEnd))
                            select s;

            var employees = from e in dbContext.Employee.Where(c => c.MainComId == MainComId)
                            select e;

            var shifts = from t in dbContext.Shift
                         select t;

            var query_shifts_employees_schedules = from e in employees
                                                   join s in schedules on e.EmployeeId equals s.EmployeeId
                                                   join t in shifts on s.ShiftId equals t.ShiftId
                                                   select new
                                                   {
                                                       s.ScheduleId,
                                                       s.IdOfMonthlyShiftEmploy,
                                                       s.ShiftId,
                                                       s.ShiftAbbrId,
                                                       t.ShiftAppliedMode,
                                                       t.ShiftName,
                                                       t.ShiftBusinessMode,
                                                       t.IsApproved,
                                                       s.EmployeeId,
                                                       s.ScheduleDate,
                                                       s.ShiftAssignedMode,
                                                       s.WorkStart,
                                                       s.WorkEnd,
                                                       s.OnDataLocked,
                                                       s.IsCompleted,
                                                       e.CnName,
                                                       e.FirstName,
                                                       e.LastName,
                                                       e.Gender,
                                                       e.ContractorId,
                                                       e.ContractorName,
                                                       e.SiteId,
                                                       e.SiteName,
                                                       e.DepartmentId,
                                                       e.DepartmentName,
                                                       e.JobId,
                                                       e.JobName,
                                                       e.PositionId,
                                                       e.PositionTitle,
                                                       e.AccessCardId
                                                   };

            //-------------------------------------------------------------------------------
            if (!String.IsNullOrEmpty(searchString))
            {
                query_shifts_employees_schedules = query_shifts_employees_schedules.Where(s => s.EmployeeId.Contains(searchString)
                                    || s.CnName.Contains(searchString)
                                    || s.FirstName.Contains(searchString)
                                    || s.ContractorName.Contains(searchString)
                                    || s.SiteName.Contains(searchString)
                                    || s.DepartmentName.Contains(searchString)
                                    || s.PositionTitle.Contains(searchString)
                                    || s.JobName.Contains(searchString)
                                    || s.AccessCardId.Contains(searchString)
                                    || s.EmployeeId.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(ContractorId))
            {
                query_shifts_employees_schedules = query_shifts_employees_schedules.Where(s => s.ContractorId == ContractorId);

            }
            if (!String.IsNullOrEmpty(SiteId))
            {
                query_shifts_employees_schedules = query_shifts_employees_schedules.Where(s => s.SiteId == SiteId);
            }
            if (!String.IsNullOrEmpty(DepartmentId))
            {
                query_shifts_employees_schedules = query_shifts_employees_schedules.Where(s => s.DepartmentId == DepartmentId);
            }
            if (!String.IsNullOrEmpty(PositionId))
            {
                query_shifts_employees_schedules = query_shifts_employees_schedules.Where(s => s.PositionId == PositionId);
            }
            if (!String.IsNullOrEmpty(JobId))
            {
                query_shifts_employees_schedules = query_shifts_employees_schedules.Where(s => s.PositionId == JobId);
            }

            #endregion

            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.CurrentContractorId = ContractorId;
            ViewBag.CurrentSiteId = SiteId;
            ViewBag.CurrentDepartmentId = DepartmentId;
            ViewBag.CurrentPositionId = PositionId;
            ViewBag.CurrentJobId = JobId;

            switch (sortOrder)
            {
                case "Date":
                    query_shifts_employees_schedules = query_shifts_employees_schedules.OrderBy(s => s.ScheduleId);
                    break;
                case "date_desc":
                    query_shifts_employees_schedules = query_shifts_employees_schedules.OrderByDescending(s => s.ScheduleId);
                    break;
                default:
                    query_shifts_employees_schedules = query_shifts_employees_schedules.OrderByDescending(s => s.ScheduleId);
                    break;
            }
            //---------------------------------------------------------------------------------------------

            int pageNumber = (page ?? 1);
            int pageSize = 500;

            string HashString = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}", ContractorId, ViewBag.CurrentScheduleDateRange, DepartmentId, JobId, PositionId, searchString, SiteId, sortOrder);
            HashString = CommonBase.HMACSHA1Encode(HashString);
            string scheduleSearchingFileName = string.Format("{0}_{1}_{2}.json", MainComId, pageNumber, HashString);
            string pathFile = Path.Combine(publicGlobalConfig.WebRootFolder, publicGlobalConfig.UploadFolder, publicGlobalConfig.DataFolder, "ScheduleChartSearching", scheduleSearchingFileName);
            string VirtualPathFile = string.Format("/{0}/{1}/{2}/{3}", publicGlobalConfig.UploadFolder, publicGlobalConfig.DataFolder, "ScheduleChartSearching", scheduleSearchingFileName);
            //---------------------------------------------------------------------------------------------------------------
            List<ScheduleEmployeeQuery> scheduleEmployeeQuerys = new List<ScheduleEmployeeQuery>();
            int j = 0;
            foreach (var item in query_shifts_employees_schedules)
            {
                Genders gender = (Genders)item.Gender;
                ScheduleEmployeeQuery scheduleEmployee = new ScheduleEmployeeQuery()
                {
                    RecIndex = j,
                    EmployeeId = item.EmployeeId,
                    Gender = gender.ToString().ToUpper().Substring(0, 1),
                    Name = string.Format("{0} {1} {2}", item.CnName, item.FirstName, item.LastName),
                    ScheduleDate = item.ScheduleDate,
                    WorkStart = item.WorkStart,
                    WorkEnd = item.WorkEnd,
                    ShiftAbbrId = item.ShiftAbbrId,
                    ShiftId = item.ShiftId,
                    ShiftName = string.Format("{0} {1}", item.ShiftAbbrId, item.ShiftName),
                    IsApproved = item.IsApproved
                };
                scheduleEmployeeQuerys.Add(scheduleEmployee);
                j++;
            }

            //-------------------------------------------------------------------------------------------------------
            bool jsonFileState;
            if (System.IO.File.Exists(pathFile))
            {
                DateTime dateTimeFileInfo = System.IO.File.GetLastWriteTime(pathFile);
                if (dateTimeFileInfo.AddDays(1) < DateTime.Now)
                {
                    jsonFileState = true;
                }
                else
                {
                    jsonFileState = false;
                }
            }
            else
            {
                jsonFileState = false;
            }

            if (jsonFileState)
            {
                ViewBag.scheduleSearchingFileName = VirtualPathFile;
            }
            else
            {
                List<ScheduleEmployeeQuery> scheduleEmployeeQueryPage = scheduleEmployeeQuerys.ToPagedList(pageNumber, pageSize).ToList();
                ScheduleChartResult scheduleChartResult = ScheduleUtilize.ScheduleChartSearching(scheduleEmployeeQueryPage, MainComId, ContractorId, SiteId, DepartmentId, PositionId, JobId, sortOrder, searchString, scheduleDateStart, scheduleDateEnd);
                var scheduleChartResultJson = JsonConvert.SerializeObject(scheduleChartResult,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

                CommonBase.SaveDataJson(scheduleChartResultJson, pathFile);
                ViewBag.scheduleSearchingFileName = VirtualPathFile;
            }
            //-------------------------------------------------------------------------------------------------------
            return View("ScheduleChart", scheduleEmployeeQuerys.ToPagedList(pageNumber, pageSize));
        }

       

        public FileStreamResult ScheduleIndexRpt(string ContractorId, string SiteId, string DepartmentId, string PositionId, string JobId,
           string sortOrder, string searchString, string scheduleDateRange, string currentFilter, int intExportFormatType)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(LangUtilities.LanguageCode);

            string outPutFileName = "ScheduleMonth31.pdf";
            string MainComId = !string.IsNullOrEmpty(WebCookie.MainComId) ? WebCookie.MainComId : dbContext.AspNetUsers.Find(User.Identity.GetUserId()).MainComId;
            string IndustryId = WebCookie.IndustryId;
            DateTimeRangeObj dateTimeRangeObj = new DateTimeRangeObj();
            DateTime dt = DateTime.Now;
            if (!string.IsNullOrEmpty(scheduleDateRange))
            {
                scheduleDateRange = this.Server.UrlDecode(scheduleDateRange);
            }
            else
            {
                scheduleDateRange = string.Format("{0:yyyy-MM-ddTHH:mm}-{1:yyyy-MM-ddTHH:mm}", dt, dt.AddDays(30));
            }

            dateTimeRangeObj = CommonBase.DateTimeRangeParse(scheduleDateRange);

            ScheduleSearchingResult scheduleSearchingResult = ScheduleUtilize.ScheduleSearching( MainComId, ContractorId, SiteId, DepartmentId, PositionId, JobId, sortOrder, searchString, dateTimeRangeObj);
            List<MonthHeader> monthHeaders = scheduleSearchingResult.monthHeaders;
            MainCom mainCom = scheduleSearchingResult.mainCom;
            //----------------------------------------------------------------------------------------------------------------------------
            DataTable ListScheduleMonth31DataTable = DataTableConvert.ListToTable(scheduleSearchingResult.ListScheduleMonth31.ToList());
            DataTable ShiftListDataTable = DataTableConvert.ListToTable(scheduleSearchingResult.ShiftList);
            //----------------------------------------------------------------------------------------------------------------------------
            string reportPath_ScheduleIndex = Server.MapPath("~/Areas/Admin/CrystalResports/ScheduleIndex.rpt");
            ReportDocument rd = new ReportDocument();
            rd.Load(reportPath_ScheduleIndex);
            //-------------------------------------------------------------------
            rd.SetDataSource(ListScheduleMonth31DataTable);
            rd.Subreports["ScheduleShiftRemarks.rpt"].SetDataSource(ShiftListDataTable);

            rd.SetParameterValue("CompanyName", mainCom.CompanyName);
            rd.SetParameterValue("Title", Lang.ScheduleIndex_Title);
            //------------------------------------------------------------------- 
            rd.SetParameterValue("ShiftRemarksTitle", Lang.Scheduleindex_ShiftRemarksTitle_Rpt, "ScheduleShiftRemarks.rpt");
            rd.SetParameterValue("HeaderShiftId", Lang.Shift_ShiftId, "ScheduleShiftRemarks.rpt");
            rd.SetParameterValue("HeaderShiftAbbrID", Lang.Shift_ShiftAbbrId, "ScheduleShiftRemarks.rpt");
            rd.SetParameterValue("HeaderShiftName", Lang.Shift_ShiftName, "ScheduleShiftRemarks.rpt");
            rd.SetParameterValue("HeaderWorkStart", Lang.Shift_WorkStart, "ScheduleShiftRemarks.rpt");
            rd.SetParameterValue("HeaderWorkEnd", Lang.Shift_WorkEnd, "ScheduleShiftRemarks.rpt");
            rd.SetParameterValue("HeaderSpecialWeekDays", Lang.Shift_SpecialWeekDays, "ScheduleShiftRemarks.rpt");
            rd.SetParameterValue("HeaderSpecialWeekDaysWorkStart", Lang.Shift_SpecialWeekDaysWorkStart, "ScheduleShiftRemarks.rpt");
            rd.SetParameterValue("HeaderSpecialWeekDaysWorkEnd", Lang.Shift_SpecialWeekDaysWorkEnd, "ScheduleShiftRemarks.rpt");
            rd.SetParameterValue("HeaderExcludeWeekDay", Lang.Shift_ExcludeWeekDay, "ScheduleShiftRemarks.rpt");

            foreach (var item in monthHeaders)
            {
                rd.SetParameterValue(string.Format("Day{0}", item.DayIndex), string.Format("{0}\n\r{1}", item.Day, item.DayOfWeekName.ToString().Substring(0, 3)));
                continue;
            }
            //rd.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "c:\\output.pdf");
            //--------------------------------------------------------------------------------------

            ExportOptions options = new ExportOptions();
            options.ExportFormatType = (ExportFormatType)intExportFormatType; //Excel = 4 PDF = 5 ExportFormatType.Excel// ExportFormatType.PortableDocFormat; 
            if (options.ExportFormatType == ExportFormatType.PortableDocFormat)
            {
                options.FormatOptions = ExportOptions.CreatePdfFormatOptions(); //new PdfRtfWordFormatOptions();
            }
            if (options.ExportFormatType == ExportFormatType.Excel)
            {
                options.FormatOptions = ExportOptions.CreateExcelFormatOptions();
                outPutFileName = "ScheduleMonth31.xlt";
            }
            ExportRequestContext req = new ExportRequestContext();
            req.ExportInfo = options;

            //rd.ExportToDisk(ExportFD:\STARON\DataGuard\DataGuard\Areas\Admin\Controllers\AttendanceReportsController.csormatType.PortableDocFormat, "c:\\output.pdf");

            Stream stream = rd.FormatEngine.ExportToStream(req);
            stream.Seek(0, SeekOrigin.Begin);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            return File(stream, "application/pdf", outPutFileName);
             
        }

        public FileStreamResult AttendanceLogRpt(string occurDateTimeRange, string sortOrder, string searchString, string currentFilter, int? page, int intExportFormatType)
        {
            string OutPutFileName = "AttendanceLogRpt.pdf";
            string MainComId = dbContext.AspNetUsers.Find(User.Identity.GetUserId()).MainComId;
            DateTime dt = DateTime.Now;
            long occurStart = dt.Ticks;
            long occurEnd = dt.Ticks;
            #region DateTimeRange
            if (string.IsNullOrEmpty(occurDateTimeRange))
            {
                occurDateTimeRange = string.Format("{0:yyyy-MM-ddTHH:mm}-{0:yyyy-MM-ddTHH:mm}", dt);
            }
            else
            {
                occurDateTimeRange = this.Server.UrlDecode(occurDateTimeRange);
            }

            DateTimeRangeObj dateTimeRangeObj = new DateTimeRangeObj();
            dateTimeRangeObj = CommonBase.DateTimeRangeParse(occurDateTimeRange);
            ViewBag.CurrentOccurDateTimeRange = string.Format("{0:yyyy-MM-ddTHH:mm}-{1:yyyy-MM-ddTHH:mm}", dateTimeRangeObj.Start, dateTimeRangeObj.End);
            #endregion
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = Server.UrlDecode(searchString);
                searchString = searchString.Trim();
                ViewBag.CurrentFilter = searchString.Trim();
                page = 1;
            }
            else
            {
                searchString = currentFilter;
                ViewBag.CurrentFilter = searchString;
            }

            #region page data
            var attendanceLog = from s in dbContext.AttendanceLog.AsNoTracking()
                                select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                attendanceLog = attendanceLog.Where(s => s.DeviceName.Contains(searchString)
                                        || s.CnName.Contains(searchString)
                                        || s.AccesscardId.Contains(searchString)
                                        || s.ContractorName.Contains(searchString)
                                        || s.ContractorId.Contains(searchString)
                                        || s.ContractorName.Contains(searchString)
                                        || s.SiteName.Contains(searchString)
                                        || s.DepartmentName.Contains(searchString)
                                        || s.PositionTitle.Contains(searchString)
                                        || s.JobName.Contains(searchString)
                                        || s.EmployeeId.Contains(searchString));
            }

            if (occurEnd > occurStart)
            {
                attendanceLog = attendanceLog.Where(s => s.OccurDateTime > occurStart && s.OccurDateTime < occurEnd);
            }
            switch (sortOrder)
            {
                case "Date":
                    attendanceLog = attendanceLog.OrderBy(s => s.OccurDateTime);
                    break;
                case "date_desc":
                    attendanceLog = attendanceLog.OrderByDescending(s => s.OccurDateTime);
                    break;
                default:
                    attendanceLog = attendanceLog.OrderByDescending(s => s.OccurDateTime);
                    break;
            }


            int pageSize = 100;
            int pageNumber = (page ?? 1);
            var attendanceLogPage = attendanceLog.ToPagedList(pageNumber, pageSize).ToList();
            #endregion

            #region return report stream 
            DataTable AttendanceLogRpt_DataTable = DataTableConvert.ListToTable(attendanceLogPage);
            //-----------------------------------------------------------------------------------------------------------------------------
            string reportPath_AttendanceLogRpt = Server.MapPath("~/Areas/Admin/CrystalResports/AttendanceLog/AttendanceLog.rpt");
            ReportDocument rd = new ReportDocument();
            rd.Load(reportPath_AttendanceLogRpt);

            //-------------------------------------------------------------------
            rd.SetDataSource(AttendanceLogRpt_DataTable);

            rd.SetParameterValue("Title", Lang.ScheduleIndex_Title);

            //--------------------------------------------------------------------------------------

            ExportOptions options = new ExportOptions();
            options.ExportFormatType = (ExportFormatType)intExportFormatType; //Excel = 4 PDF = 5 ExportFormatType.Excel// ExportFormatType.PortableDocFormat; 
            if (options.ExportFormatType == ExportFormatType.PortableDocFormat)
            {
                options.FormatOptions = ExportOptions.CreatePdfFormatOptions(); //new PdfRtfWordFormatOptions();
            }
            if (options.ExportFormatType == ExportFormatType.Excel)
            {
                options.FormatOptions = ExportOptions.CreateExcelFormatOptions();
                OutPutFileName = "AttendanceLogRpt.xlt";
            }
            ExportRequestContext req = new ExportRequestContext();
            req.ExportInfo = options;

            Stream stream = rd.FormatEngine.ExportToStream(req);
            stream.Seek(0, SeekOrigin.Begin);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            return File(stream, "application/pdf", OutPutFileName);

            #endregion  
        }
        public static MemoryStream ToMemoryStream(ReportClass report, ExportFormatType formatType)
        {
            try
            {
                Stream s = report.ExportToStream(formatType);
                MemoryStream stream = new MemoryStream();
                s.CopyTo(stream);
                s.Close();
                return stream;
            }
            catch
            {
                return null;
            }

        }
        //public FileStreamResult ScheduleIndexRptOK(string ContractorId, string SiteId, string DepartmentId, string PositionId, string JobId,
        //  string sortOrder, string searchString, string scheduleDateRange, string currentFilter, int intExportFormatType)
        //{
        //    string MainComId = !string.IsNullOrEmpty(WebCookie.MainComId) ? WebCookie.MainComId : dbContext.AspNetUsers.Find(User.Identity.GetUserId()).MainComId;
        //    string IndustryId = WebCookie.IndustryId;

        //    ScheduleSearchingResult scheduleSearchingResult = ScheduleUtilize.ScheduleSearching(this.dbContext, MainComId, ContractorId, SiteId, DepartmentId, PositionId, JobId, sortOrder, searchString, scheduleDateRange);
        //    List<MonthHeader> monthHeaders = scheduleSearchingResult.monthHeaders;
        //    MainCom mainCom = scheduleSearchingResult.mainCom;
        //    //-----------------------------------------------------------------------------------------------------------------------------

        //    //DataSet1 dataSet = new DataSet1();
        //    //dataSet.Tables[0].DefaultView = scheduleSearchingResult.ListScheduleMonth31;

        //    //ReportDocument oRD = new ReportDocument();
        //    //ExportOptions oExO;
        //    //DiskFileDestinationOptions oExDo = new DiskFileDestinationOptions();
        //    //string reportPath = Server.MapPath("~/Areas/Admin/CrystalResports/ScheduleIndex.rpt"); 
        //    //oRD.Load(reportPath);
        //    //oRD.SetDataSource(scheduleSearchingResult.ListScheduleMonth31);
        //    //oRD.Refresh();  
        //    //oExDo.DiskFileName = "ScheduleIndex.pdf";
        //    //oExO = oRD.ExportOptions;
        //    //oExO.ExportDestinationType = ExportDestinationType.DiskFile;
        //    //oExO.ExportFormatType = ExportFormatType.PortableDocFormat;

        //    //oExO.DestinationOptions = oExDo;

        //    //oRD.Export();
        //    //oRD.Close();

        //    string reportPath_ScheduleIndex = Server.MapPath("~/Areas/Admin/CrystalResports/ScheduleIndex.rpt");
        //    ReportDocument rd = new ReportDocument();
        //    rd.Load(reportPath_ScheduleIndex);
        //    //--------------------------------------------------------
        //    ParameterFields paramFields = new ParameterFields();
        //    ParameterField paramField = new ParameterField();
        //    ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
        //    paramField.Name = "CompanyName";

        //    paramDiscreteValue.Value = mainCom.CompanyName;
        //    paramField.CurrentValues.Add(paramDiscreteValue);
        //    //Add the paramField to paramFields
        //    paramFields.Add(paramField);
        //    //-------------------------------------------------------------------
        //    rd.SetDataSource(scheduleSearchingResult.ListScheduleMonth31);
        //    rd.SetParameterValue("CompanyName", mainCom.CompanyName);
        //    rd.SetParameterValue("Title", Lang.ScheduleIndex_Title);
        //    foreach (var item in monthHeaders)
        //    {
        //        rd.SetParameterValue(string.Format("Day{0}", item.DayIndex), string.Format("{0}\n\r{1}", item.Day, item.DayOfWeekName.ToString().Substring(0, 3)));
        //        continue;
        //    }
        //    ExportOptions options = new ExportOptions();
        //    options.ExportFormatType = (ExportFormatType)intExportFormatType; //Excel = 4 PDF = 5 ExportFormatType.Excel// ExportFormatType.PortableDocFormat; 
        //    options.FormatOptions = new PdfRtfWordFormatOptions();
        //    ExportRequestContext req = new ExportRequestContext();
        //    req.ExportInfo = options;

        //    Stream stream = rd.FormatEngine.ExportToStream(req);
        //    stream.Seek(0, SeekOrigin.Begin);
        //    Response.Buffer = false;
        //    Response.ClearContent();
        //    Response.ClearHeaders();
        //    return File(stream, "application/pdf", "ScheduleMonth31.pdf");

        //    #region
        //    //ParameterValues pvHeaderShiftId = new ParameterValues();
        //    //ParameterDiscreteValue pdHeaderShiftId = new ParameterDiscreteValue();
        //    //pdHeaderShiftId.Value = Lang.Shift_ShiftId;
        //    //pvHeaderShiftId.Add(pdHeaderShiftId);
        //    //rd.DataDefinition.ParameterFields["HeaderShiftId", "ScheduleShiftRemarks1"].ApplyCurrentValues(pvHeaderShiftId);

        //    //ParameterValues pvHeaderShiftAbbrID = new ParameterValues();
        //    //ParameterDiscreteValue pdHeaderShiftAbbrID = new ParameterDiscreteValue();
        //    //pdHeaderShiftAbbrID.Value = Lang.Shift_ShiftId;
        //    //pvHeaderShiftAbbrID.Add(pdHeaderShiftAbbrID);
        //    //rd.DataDefinition.ParameterFields["HeaderShiftAbbrID", "ScheduleShiftRemarks1"].ApplyCurrentValues(pvHeaderShiftAbbrID);

        //    // //switch (docFormat)
        //    //{
        //    //    case "pdf ":
        //    //        oExO.ExportFormatType = ExportFormatType.PortableDocFormat;
        //    //        break;
        //    //    case "doc ":
        //    //        oExO.ExportFormatType = ExportFormatType.WordForWindows;
        //    //        break;
        //    //    case "xls ":
        //    //        oExO.ExportFormatType = ExportFormatType.Excel;
        //    //        break;
        //    //    case "htm ":
        //    //        oExO.ExportFormatType = ExportFormatType.HTML40;
        //    //        break;
        //    //    case "html ":
        //    //        oExO.ExportFormatType = ExportFormatType.HTML40;
        //    //        break;
        //    //    default: oExO.ExportFormatType = ExportFormatType.Excel; break;
        //    //}
        //    #endregion format
        //}
         
        [HttpGet]
        public JsonResult AttendanceByShiftChkDataRecruitment(string id)
        {
            ModalDialog modalDialog = new ModalDialog
            {
                //false = 0
                MsgCode = "0",
                Message = string.Format("{1}\n({0})", id, Lang.AttendanceByShift_NoDataRecruitment)
            };
            AttendanceByShift asttendanceByShift = dbContext.AttendanceByShift.Find(id);
            string HmacHash = asttendanceByShift.HmacHash;

            if (asttendanceByShift == null)
            {
                modalDialog.MsgCode = "1";
                modalDialog.Message = string.Format("{1}\n({0})", id, Lang.GeneralUI_NotExistRecord);
            }
            string HmacHashCompare = ScheduleAndShiftUtil.AttendanceByShiftHmac(asttendanceByShift);
            if (HmacHash != HmacHashCompare)
            {
                modalDialog.MsgCode = "1";
                modalDialog.Message = string.Format("{1} \n({0})", id, Lang.AttendanceByShift_ExistDataRecruitme);
            }
            return Json(modalDialog, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult AttendanceByDayChkDataRecruitment(string id)
        {
            ModalDialog modalDialog = new ModalDialog
            {
                //false = 0
                MsgCode = "0",
                Message = string.Format("{1}\n({0})", id, Lang.GeneralUI_NoDataRecruitment)
            };
            AttendanceByDay asttendanceByDay = dbContext.AttendanceByDay.Find(id);
            string HmacHash = asttendanceByDay.HmacHash;

            if (asttendanceByDay == null)
            {
                modalDialog.MsgCode = "1";
                modalDialog.Message = string.Format("{1}\n({0})", id, Lang.GeneralUI_NotExistRecord);
            }
            string HmacHashCompare = ScheduleAndShiftUtil.AttendanceByDayHmac(asttendanceByDay);
            if (HmacHash != HmacHashCompare)
            {
                modalDialog.MsgCode = "1";
                modalDialog.Message = string.Format("{1} \n({0})", id, Lang.GeneralUI_ExistDataRecruitme);
            }
            return Json(modalDialog, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult AttendanceByPeriodChkDataRecruitment(string id)
        {
            ModalDialog modalDialog = new ModalDialog
            {
                //false = 0
                MsgCode = "0",
                Message = string.Format("{1}\n({0})", id, Lang.GeneralUI_NoDataRecruitment)
            };
            AttendanceByPeriod attendanceByPeriod = dbContext.AttendanceByPeriod.Find(id);
            string HmacHash = attendanceByPeriod.HmacHash;

            if (attendanceByPeriod == null)
            {
                modalDialog.MsgCode = "1";
                modalDialog.Message = string.Format("{1}\n({0})", id, Lang.GeneralUI_NotExistRecord);
            }
            string HmacHashCompare = ScheduleAndShiftUtil.AttendanceByPeriodHmac(attendanceByPeriod);
            if (HmacHash != HmacHashCompare)
            {
                modalDialog.MsgCode = "1";
                modalDialog.Message = string.Format("{1} \n({0})", id, Lang.GeneralUI_ExistDataRecruitme);
            }
            return Json(modalDialog, JsonRequestBehavior.AllowGet);
        }
        [AccessAuthorize]
        [HttpPost]
        public JsonResult RefreshAttendanceByPeriod(string attendanceByPeriodId)
        {
            ResponseModal responseModal = new ResponseModal();
            
            AttendanceByPeriod attendanceByPeriod = new AttendanceByPeriod();
            using (DataBaseContext dataBaseContext = new DataBaseContext())
            {
                attendanceByPeriod = dataBaseContext.AttendanceByPeriod.Find(attendanceByPeriodId);
                if (attendanceByPeriod != null)
                {
                    int month = attendanceByPeriod.StartDate.Month;
                    string employeeId = attendanceByPeriod.EmployeeId;

                    var attendanceByDays = dataBaseContext.AttendanceByDay.Where(c => c.EmployeeId == employeeId && c.OccurDate.Month == month).ToList();
                    bool IsCompletedStatusChange = !attendanceByPeriod.IsCompleted;
                    int count = attendanceByDays.Count();
                    attendanceByDays.ForEach(c => c.IsCompleted = IsCompletedStatusChange);
                    dataBaseContext.AttendanceByDay.UpdateRange(attendanceByDays);
                    int result = dataBaseContext.SaveChanges() ;
                    if (result > 0)
                    {
                        int[] days = attendanceByDays.Select(c => c.OccurDate.Day).Distinct().ToArray();
                        responseModal.meta = new MetaModal
                        {
                            Success = true,
                            ErrorCode = -1,
                            Message = string.Format("[SUCCESS] [OK] [DAY : {0}] [COUNT = {1}]", string.Join(",", days), count)
                        };
                    }
                    else
                    {
                        responseModal.meta = new MetaModal
                        {
                            Success = false,
                            ErrorCode = 12312456,
                            Message = string.Format("[FAIL] [NO REAL DATA FOR THIS MONTH] [IN AttendanceByDay] ")
                        };

                    }
                }
                else
                {
                    responseModal.meta = new MetaModal { Success = false, ErrorCode = 12001, Message = "By Month Not Exists" };
                }
                return Json(responseModal, JsonRequestBehavior.AllowGet);
            }
        }

        [AccessAuthorize]
        [HttpPost]
        public JsonResult RefreshAttendanceByDay(string attendanceByDayId)
        {
            ResponseModal responseModal = new ResponseModal();
            //-----
            AttendanceByDay attendanceByDay = new AttendanceByDay();
            using (DataBaseContext dataBaseContext = new DataBaseContext())
            {
                attendanceByDay = dataBaseContext.AttendanceByDay.Find(attendanceByDayId);
                if (attendanceByDay != null)
                {
                    DateTime scheduleDate = attendanceByDay.OccurDate;
                    string employeeId = attendanceByDay.EmployeeId;

                    var attendanceByShifts = dataBaseContext.AttendanceByShift.Where(c => c.EmployeeId == employeeId && c.ScheduleDate.Date == scheduleDate.Date);
                    attendanceByShifts.ForEach(c => c.IsCompleted = false);
                    dataBaseContext.AttendanceByShift.UpdateRange(attendanceByShifts);
                    bool result = dataBaseContext.SaveChanges() > 0 ? true : false;
                    if (result)
                    {
                        bool ChangeScheduleAndShiftStatus_result = AttendanceByDayCalc.ChangeScheduleAndShiftStatus(employeeId, scheduleDate, false);
                        responseModal.meta = new MetaModal
                        {
                            Success = true,
                            ErrorCode = -1,
                            Message = string.Format("[SUCCESS] [OK] [{0}]" +
                            "\n\n[{1}", ChangeScheduleAndShiftStatus_result.ToString().ToUpper(), Lang.GeneralUI_PleaseWaiting)
                        };
                    }
                }
                else
                {
                    responseModal.meta = new MetaModal { Success = false, ErrorCode = 12001, Message = "ByShifts Not Exists" };
                }
                return Json(responseModal, JsonRequestBehavior.AllowGet);
            }
        }

        [AccessAuthorize]
        [HttpPost]
        public JsonResult RefreshAttendanceByShift(string attendanceByShiftId)
        {
            ResponseModal responseModal = new ResponseModal();
            AttendanceByShift attendanceByShift = new AttendanceByShift();
            using (DataBaseContext dataBaseContext = new DataBaseContext())
            {
                attendanceByShift = dataBaseContext.AttendanceByShift.Find(attendanceByShiftId);
                if (attendanceByShift != null)
                {
                    DateTime scheduleDate = attendanceByShift.ScheduleDate;
                    string employeeId = attendanceByShift.EmployeeId;

                    var schedules = dataBaseContext.Schedule.Where(c => c.EmployeeId == employeeId && c.ScheduleDate.Date == scheduleDate.Date);
                    schedules.ForEach(c => c.IsCompleted = false);
                    dataBaseContext.Schedule.UpdateRange(schedules);
                    bool result = dataBaseContext.SaveChanges() > 0 ? true : false;
                    if (result)
                    {
                        bool ChangeScheduleAndShiftStatus_result = AttendanceByDayCalc.ChangeScheduleAndShiftStatus(employeeId, scheduleDate, false);
                        responseModal.meta = new MetaModal
                        {
                            Success = true,
                            ErrorCode = -1,
                            Message = string.Format("[SUCCESS] [OK] [{0}]" +
                            "\n\n[{1}]", ChangeScheduleAndShiftStatus_result.ToString().ToUpper(), Lang.GeneralUI_PleaseWaiting)
                        };
                    }
                }
                else
                {
                    responseModal.meta = new MetaModal { Success = false, ErrorCode = 12001, Message = "[ByShifts Not Exists]" };
                }
                return Json(responseModal, JsonRequestBehavior.AllowGet);
            } 
        }
        
        [HttpGet]
        public ActionResult ShiftReports(string ContractorId, string SiteId, string DepartmentId, string PositionId, string JobId,
           string sortOrder, string searchString, string scheduleDateRange, string currentFilter, int? page)
        {
            ModalDialog modalDialog = new ModalDialog();
            
            string IndustryId = WebCookie.IndustryId;

            this.ContractorIdDropDownList(ContractorId);
            SiteIdDropDownList(SiteId);
            DepartmentIdDropDownList(DepartmentId);
            PositionIdDropDownList(IndustryId, PositionId);
            IndustryIdDropDownList(IndustryId, JobId);
            JobIdDropDownList(IndustryId, JobId);
            //---------------------------------------------------------------------
            DateTimeRangeObj dateTimeRangeObj = new DateTimeRangeObj();
            DateTime dt = DateTime.Now;

            if (!string.IsNullOrEmpty(scheduleDateRange))
            {
                scheduleDateRange = this.Server.UrlDecode(scheduleDateRange);
                dateTimeRangeObj = CommonBase.DateTimeRangeParse(scheduleDateRange);
                dateTimeRangeObj.Start = DateTimePubBusiness.SetZeroSecond(dateTimeRangeObj.Start);
                dateTimeRangeObj.End = Convert2359ToZero(dateTimeRangeObj.End); //case filter
                ViewBag.CurrentScheduleDateRange = string.Format("{0:yyyy-MM-ddTHH:mm}-{1:yyyy-MM-ddTHH:mm}", dateTimeRangeObj.Start, dateTimeRangeObj.End);
            }
            else
            {
                dateTimeRangeObj.Start = dt;
                dateTimeRangeObj.End = dt;
                ViewBag.CurrentOccurDateTimeRange = string.Format("{0:yyyy-MM-ddT00:00}-{0:yyyy-MM-ddT00:00}", dt);
            }
            if (dateTimeRangeObj.Start.Date == dateTimeRangeObj.End.Date)
            {
                dateTimeRangeObj.Start = dateTimeRangeObj.Start.AddDays(-30);
            }
            if (String.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "date_desc";
            }
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.CurrentContractorId = ContractorId;
            ViewBag.CurrentSiteId = SiteId;
            ViewBag.CurrentDepartmentId = DepartmentId;
            ViewBag.CurrentPositionId = PositionId;
            ViewBag.CurrentJobId = JobId;

            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = Server.UrlDecode(searchString);
                searchString = searchString.Trim();
                ViewBag.CurrentFilter = searchString.Trim();
                page = 1;
            }
            else
            {
                searchString = currentFilter;
                ViewBag.CurrentFilter = searchString;
            }

            var attendanceByShifts = from s in dbContext.AttendanceByShift.AsNoTracking()
                                     select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                attendanceByShifts = attendanceByShifts.Where(s => s.ShiftName.Contains(searchString)
                                        || s.EmployeeId.Contains(searchString)
                                        || s.EmployeeName.Contains(searchString)
                                        || s.ContractorName.Contains(searchString)
                                        || s.ContractorName.Contains(searchString)
                                        || s.SiteName.Contains(searchString)
                                        || s.DepartmentName.Contains(searchString)
                                        || s.PositionTitle.Contains(searchString)
                                        || s.JobName.Contains(searchString));
            }

            attendanceByShifts = attendanceByShifts.OrderByDescending(s => s.ScheduleDate);

            int pageSize = 60;
            int pageNumber = (page ?? 1);
            return View(attendanceByShifts.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult ShiftBrief(string ContractorId, string SiteId, string DepartmentId, string PositionId, string JobId,
           string sortOrder, string searchString, string scheduleDateRange, string currentFilter, int? page)
        {
            ModalDialog modalDialog = new ModalDialog();
            string IndustryId = WebCookie.IndustryId;

            this.ContractorIdDropDownList(ContractorId);
            SiteIdDropDownList(SiteId);
            DepartmentIdDropDownList(DepartmentId);
            PositionIdDropDownList(IndustryId, PositionId);
            IndustryIdDropDownList(IndustryId, JobId);
            JobIdDropDownList(IndustryId, JobId);
            //---------------------------------------------------------------------
            DateTimeRangeObj dateTimeRangeObj = new DateTimeRangeObj();
            DateTime dt = DateTime.Now;

            if (!string.IsNullOrEmpty(scheduleDateRange))
            {
                scheduleDateRange = this.Server.UrlDecode(scheduleDateRange);
                dateTimeRangeObj = CommonBase.DateTimeRangeParse(scheduleDateRange);
                dateTimeRangeObj.Start = DateTimePubBusiness.SetZeroSecond(dateTimeRangeObj.Start);
                dateTimeRangeObj.End = Convert2359ToZero(dateTimeRangeObj.End); //case filter
                ViewBag.CurrentScheduleDateRange = string.Format("{0:yyyy-MM-ddTHH:mm}-{1:yyyy-MM-ddTHH:mm}", dateTimeRangeObj.Start, dateTimeRangeObj.End);
            }
            else
            {
                dateTimeRangeObj.Start = dt;
                dateTimeRangeObj.End = dt;
                ViewBag.CurrentOccurDateTimeRange = string.Format("{0:yyyy-MM-ddT00:00}-{0:yyyy-MM-ddT00:00}", dt);
            }
            if (dateTimeRangeObj.Start.Date == dateTimeRangeObj.End.Date)
            {
                dateTimeRangeObj.Start = dateTimeRangeObj.Start.AddDays(-30);
            }
            if (String.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "date_desc";
            }
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.CurrentContractorId = ContractorId;
            ViewBag.CurrentSiteId = SiteId;
            ViewBag.CurrentDepartmentId = DepartmentId;
            ViewBag.CurrentPositionId = PositionId;
            ViewBag.CurrentJobId = JobId;

            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = Server.UrlDecode(searchString);
                searchString = searchString.Trim();
                ViewBag.CurrentFilter = searchString.Trim();
                page = 1;
            }
            else
            {
                searchString = currentFilter;
                ViewBag.CurrentFilter = searchString;
            }

            var attendanceByShifts = from s in dbContext.AttendanceByShift
                                     select s;
             

            switch (sortOrder)
            {
                case "Date":
                    attendanceByShifts = attendanceByShifts.OrderBy(s => s.ScheduleDate);
                    break;
                case "date_desc":
                    attendanceByShifts = attendanceByShifts.OrderByDescending(s => s.ScheduleDate);
                    break;
                default:
                    attendanceByShifts = attendanceByShifts.OrderByDescending(s => s.ScheduleDate);
                    break;
            }
            int pageSize = 60;
            int pageNumber = (page ?? 1);
            return View(attendanceByShifts.ToPagedList(pageNumber, pageSize));
        }
         

        [HttpGet]
        public ActionResult DayStatistics(string ContractorId, string SiteId, string DepartmentId, string PositionId, string JobId,
           string sortOrder, string searchString, string scheduleDateRange, string currentFilter, int? page)
        {
            ResponseModal responseModal = new ResponseModal(); 
            string IndustryId = WebCookie.IndustryId;

            this.ContractorIdDropDownList(ContractorId);
            SiteIdDropDownList(SiteId);
            DepartmentIdDropDownList(DepartmentId);
            PositionIdDropDownList(IndustryId, PositionId);
            IndustryIdDropDownList(IndustryId, JobId);
            JobIdDropDownList(IndustryId, JobId);
            //---------------------------------------------------------------------
            DateTimeRangeObj dateTimeRangeObj = new DateTimeRangeObj();
            DateTime dt = DateTime.Now;
            dateTimeRangeObj.Start = dt;
            dateTimeRangeObj.End = dt;
            long scheduleDateStart = dt.Ticks;
            long scheduleDateEnd = dt.Ticks;
            string CurrentScheduleDateRange = "";
            if (!string.IsNullOrEmpty(scheduleDateRange))
            {
                scheduleDateRange = this.Server.UrlDecode(scheduleDateRange); 
                dateTimeRangeObj = CommonBase.DateTimeRangeParse(scheduleDateRange); 
                CurrentScheduleDateRange = string.Format("{0:yyyy-MM-ddTHH:mm}-{1:yyyy-MM-ddTHH:mm}", dateTimeRangeObj.Start, dateTimeRangeObj.End);
                ViewBag.CurrentScheduleDateRange = CurrentScheduleDateRange;
            }
            else
            {
                CurrentScheduleDateRange = string.Format("{0:yyyy-MM-ddTHH:mm}-{1:yyyy-MM-ddTHH:mm}", dt, dt);
                ViewBag.CurrentScheduleDateRange = CurrentScheduleDateRange; 
            }
             
            if (String.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "date_desc";
            }
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.CurrentContractorId = ContractorId;
            ViewBag.CurrentSiteId = SiteId;
            ViewBag.CurrentDepartmentId = DepartmentId;
            ViewBag.CurrentPositionId = PositionId;
            ViewBag.CurrentJobId = JobId;

            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = Server.UrlDecode(searchString);
                searchString = searchString.Trim();
                ViewBag.CurrentFilter = searchString.Trim();
                page = 1;
            }
            else
            {
                searchString = currentFilter;
                ViewBag.CurrentFilter = searchString;
            }

            var attendanceByDays = from s in dbContext.AttendanceByDay
                                   select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                attendanceByDays = attendanceByDays.Where(s => s.DayShiftNameList.Contains(searchString)
                                        || s.EmployeeId.Contains(searchString)
                                        || s.EmployeeName.Contains(searchString)
                                        || s.ContractorName.Contains(searchString)
                                        || s.ContractorId.Contains(searchString)
                                        || s.ContractorName.Contains(searchString)
                                        || s.SiteName.Contains(searchString)
                                        || s.DepartmentName.Contains(searchString)
                                        || s.PositionTitle.Contains(searchString)
                                        || s.JobName.Contains(searchString));
            }

            if (dateTimeRangeObj.End > dateTimeRangeObj.Start)
            {
                attendanceByDays = attendanceByDays.Where(c => c.OccurDate.Date >= dateTimeRangeObj.Start.Date && c.OccurDate <= dateTimeRangeObj.End.Date);
            }
            switch (sortOrder)
            {
                case "Date":
                    attendanceByDays = attendanceByDays.OrderBy(s => s.OccurDate);
                    break;
                case "date_desc":
                    attendanceByDays = attendanceByDays.OrderByDescending(s => s.OccurDate);
                    break;
                default:
                    attendanceByDays = attendanceByDays.OrderByDescending(s => s.OccurDate);
                    break;
            }
            int pageSize = 60;
            int pageNumber = (page ?? 1);
            return View(attendanceByDays.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult MonthlyStatistics(string ContractorId, string SiteId, string DepartmentId, string PositionId, string JobId,
          string sortOrder, string searchString, string scheduleDateRange, string currentFilter, int? page)
        {
            ResponseModal responseModal = new ResponseModal();
            string IndustryId = WebCookie.IndustryId;

            this.ContractorIdDropDownList(ContractorId);
            SiteIdDropDownList(SiteId);
            DepartmentIdDropDownList(DepartmentId);
            PositionIdDropDownList(IndustryId, PositionId);
            IndustryIdDropDownList(IndustryId, JobId);
            JobIdDropDownList(IndustryId, JobId);
            //---------------------------------------------------------------------
            DateTimeRangeObj dateTimeRangeObj = new DateTimeRangeObj();
            DateTime dt = DateTime.Now;
            dateTimeRangeObj.Start = dt;
            dateTimeRangeObj.End = dt;
           
            string CurrentScheduleDateRange = "";
            if (!string.IsNullOrEmpty(scheduleDateRange))
            {
                scheduleDateRange = this.Server.UrlDecode(scheduleDateRange);

                dateTimeRangeObj = CommonBase.DateTimeRangeParse(scheduleDateRange);

                CurrentScheduleDateRange = string.Format("{0:yyyy-MM-ddTHH:mm}-{1:yyyy-MM-ddTHH:mm}", dateTimeRangeObj.Start, dateTimeRangeObj.End);
                ViewBag.CurrentScheduleDateRange = CurrentScheduleDateRange;
            }
            else
            {
                CurrentScheduleDateRange = string.Format("{0:yyyy-MM-ddTHH:mm}-{1:yyyy-MM-ddTHH:mm}", dt, dt);
                ViewBag.CurrentScheduleDateRange = CurrentScheduleDateRange;
                ;
            }
            
            if (String.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "date_desc";
            }
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.CurrentContractorId = ContractorId;
            ViewBag.CurrentSiteId = SiteId;
            ViewBag.CurrentDepartmentId = DepartmentId;
            ViewBag.CurrentPositionId = PositionId;
            ViewBag.CurrentJobId = JobId;

            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = Server.UrlDecode(searchString);
                searchString = searchString.Trim();
                ViewBag.CurrentFilter = searchString.Trim();
                page = 1;
            }
            else
            {
                searchString = currentFilter;
                ViewBag.CurrentFilter = searchString;
            }

            var attendanceByPeriods = from s in dbContext.AttendanceByPeriod.AsNoTracking()
                                   select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                attendanceByPeriods = attendanceByPeriods.Where(s => 
                                        s.EmployeeId.Contains(searchString)
                                        || s.EmployeeName.Contains(searchString)
                                        || s.ContractorName.Contains(searchString)
                                        || s.ContractorId.Contains(searchString)
                                        || s.ContractorName.Contains(searchString)
                                        || s.SiteName.Contains(searchString)
                                        || s.DepartmentName.Contains(searchString)
                                        || s.PositionTitle.Contains(searchString)
                                        || s.JobName.Contains(searchString));
            }

            if (dateTimeRangeObj.End.Date != dateTimeRangeObj.Start.Date)
            {
                attendanceByPeriods = attendanceByPeriods.Where(c => c.StartDate.Date >= dateTimeRangeObj.Start.Date && c.EndDate.Date <= dateTimeRangeObj.End.Date);
            }
            switch (sortOrder)
            {
                case "Date":
                    attendanceByPeriods = attendanceByPeriods.OrderBy(s => s.StartDate);
                    break;
                case "date_desc":
                    attendanceByPeriods = attendanceByPeriods.OrderByDescending(s => s.StartDate);
                    break;
                default:
                    attendanceByPeriods = attendanceByPeriods.OrderByDescending(s => s.StartDate);
                    break;
            }
             
            int pageSize = 60;
            int pageNumber = (page ?? 1);
            IEnumerable<AttendanceByPeriod> enumerables = attendanceByPeriods.ToPagedList(pageNumber, pageSize); 
            responseModal.data = enumerables;
            return View(responseModal);
        }
        protected override void ExecuteCore()
        {
            throw new NotImplementedException();
        }

        private DateTime Convert2359ToZero(DateTime ifDt2359)
        {
            TimeSpan ts2359 = new TimeSpan(23, 59, 0, 0);
            if (ifDt2359.TimeOfDay == ts2359)
            {
                DateTime dtZeroTimeSpan = new DateTime(ifDt2359.Year, ifDt2359.Month, ifDt2359.Day, 0, 0, 0, 0);
                return dtZeroTimeSpan;
            }
            else
            {
                return ifDt2359;
            }
        }
    }
}