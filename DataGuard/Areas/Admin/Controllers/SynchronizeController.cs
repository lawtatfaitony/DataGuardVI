using AttendanceBussiness;
using AttendanceBussiness.DbFirst;
using AttendanceBussiness.Public;
using Common;
using DataGuard.App_Start;
using DataGuard.Context;
using LanguageResource;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using X.PagedList;
using static AttendanceBussiness.ShiftBusiness;

namespace DataGuard.Areas.Admin.Controllers
{
    public class SynchronizeController : BaseController
    {
        // GET: Admin/Synchronize
        public ActionResult Index()
        {
            return View();
        }
        [AccessAuthorize(Roles = "SystemAdmin,Admin,MainComOperator")]
        [HttpGet]
        public ActionResult List(string currentFilter, string searchString, int? page, SynchronizeMode synchronizeMode = 0)
        {
            ViewBag.SynchronizeMode = synchronizeMode;
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = Server.UrlDecode(searchString);
                searchString = searchString.Trim();
                ViewBag.CurrentFilter = searchString.Trim();
                page = 1;
            }
            else
            {
                if (!string.IsNullOrEmpty(currentFilter))
                {
                    searchString = currentFilter;
                }
                else
                {
                    searchString = string.Empty;
                }

                ViewBag.CurrentFilter = searchString;
            }
            SynchronizeView synchronizeView1 = new SynchronizeView
            {
                The3rdPartyEmployeeId = " The3rd1",
                CnName = "劉德華",
                FirstName = "Example",
                LastName = "",
                PhoneNumber = "12312321",
                IdNumber = "P234241",
                AccessCardId = "433223123",
                ContractorId = "Con002",
                SiteId = "S004",
                DepartmentId = "007",
                JobId = "J000110",
                PositionId = "001"
            };

            List<SynchronizeView> listSynchronizeViews = new List<SynchronizeView>
            {
                synchronizeView1
            };

            GlobalConfig globalConfig = new GlobalConfig();
            #region
            int tryTen = 0;
            if (synchronizeMode != SynchronizeMode.CWRG)
            {
                string PathExcel1 = Path.Combine(globalConfig.WebRootFolder, globalConfig.UploadFolder, "Data", "ImportEmployee", "ImportAttendance.xlsx");
                if (System.IO.File.Exists(PathExcel1))
                {
                    ReaderWriterLockSlim LogWriteLock = new ReaderWriterLockSlim();
                    DataTable table1 = new DataTable();
                    while (tryTen < 10)
                    {
                        try
                        {
                            LogWriteLock.EnterWriteLock();
                            table1 = CommonBase.ReadExcel(PathExcel1);
                            tryTen = 10;
                        }
                        catch (IOException e)
                        {
                            throw e;
                        }
                        finally
                        {
                            LogWriteLock.ExitWriteLock();
                        }
                        tryTen++;
                        Thread.Sleep(10);
                    }

                    if (table1.Rows.Count > 0 && table1.Columns.Count == 12)
                    {
                        foreach (System.Data.DataRow item in table1.Rows)
                        {
                            SynchronizeView synchronizeViewX = new SynchronizeView
                            {
                                synchronizeMode = synchronizeMode,
                                The3rdPartyEmployeeId = item[0].ToString(),
                                CnName = item[1].ToString(),
                                FirstName = item[2].ToString(),
                                LastName = item[3].ToString(),
                                PhoneNumber = item[4].ToString(),
                                IdNumber = item[5].ToString(),
                                AccessCardId = item[6].ToString(),
                                ContractorId = item[7].ToString(),
                                SiteId = item[8].ToString(),
                                DepartmentId = item[9].ToString(),
                                JobId = item[10].ToString(),
                                PositionId = item[11].ToString()
                            };
                            listSynchronizeViews.Add(synchronizeViewX);
                        }
                    }
                    else
                    {
                        CommonBase.OperateDateLoger("[Synchronize::List] occur an error when read the ImportAttendance.xlsx file format (at least 11 columns)");
                    }

                }

            }

            if (synchronizeMode == SynchronizeMode.CWRG)
            {
                List<SynchronizeView> listSynchronizeCWRGs = new List<SynchronizeView>();
                string CWRG_PathXml = Path.Combine(globalConfig.WebRootFolder, globalConfig.UploadFolder, "Data", "ImportEmployee", "Namelist.xml");
                if (System.IO.File.Exists(CWRG_PathXml))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(CWRG_PathXml);
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            SynchronizeView synchronizeViewX = new SynchronizeView
                            {
                                synchronizeMode = synchronizeMode,
                                The3rdPartyEmployeeId = row["The3rdPartyEmployeeId"].ToString(),
                                CnName = row["CnName"].ToString(),
                                FirstName = row["FirstName"].ToString(),
                                LastName = row["LastName"].ToString(),
                                PhoneNumber = row["PhoneNumber"].ToString(),
                                IdNumber = row["IdNumber"].ToString(),
                                AccessCardId = row["AccessCardId"].ToString(),
                                ContractorId = row["ContractorId"].ToString(),
                                SiteId = row["SiteId"].ToString(),
                                DepartmentId = row["DepartmentId"].ToString(),
                                JobId = row["JobId"].ToString(),
                                PositionId = row["PositionId"].ToString()
                            };
                            listSynchronizeCWRGs.Add(synchronizeViewX);
                        }
                        if (listSynchronizeCWRGs.Count() > 0)
                        {
                            listSynchronizeViews.AddRange(listSynchronizeCWRGs);
                        }
                    }
                }
            }
            #endregion

            listSynchronizeViews = listSynchronizeViews.Where(s => s.FirstName.Contains(searchString)
                                       || s.LastName.Contains(searchString)
                                       || s.CnName.Contains(searchString)
                                       || s.AccessCardId.Contains(searchString)
                                       || s.PhoneNumber.Contains(searchString)
                                       || s.IdNumber.Contains(searchString)
                                       || s.The3rdPartyEmployeeId.Contains(searchString)
                                       || s.ContractorId.Contains(searchString)
                                       || s.JobId.Contains(searchString)
                                       || s.FullName.Contains(searchString)).ToList();

            int pageSize = 30;
            int pageNumber = (page ?? 1);
            return View(listSynchronizeViews.ToPagedList(pageNumber, pageSize));
        }
        private static IList<string> GetTablenames(DataTableCollection tables)
        {
            var tableList = new List<string>();
            foreach (var table in tables)
            {
                tableList.Add(table.ToString());
            }

            return tableList;
        }
         
        public ActionResult StandardImport()
        {
            GlobalConfig globalConfig = new GlobalConfig();
            string DownloadExcelFormatFolder = "DownloadExcelFormat";
            string DownloadExcelFormat = "ImportAttendance.xlsx";
            ViewBag.DownloadExcelFormatUrl = string.Format("/{0}/{1}/{2}/{3}", globalConfig.UploadFolder, globalConfig.DataFolder, DownloadExcelFormatFolder, DownloadExcelFormat);
            return View();
        }
        [HttpPost]
        public JsonResult StandardImport(HttpPostedFileBase excel_file_upload)
        {
            GlobalConfig globalConfig = new GlobalConfig();
            string root = AppDomain.CurrentDomain.BaseDirectory;
            string PathExcel1 = Path.Combine(root, globalConfig.UploadFolder, globalConfig.DataFolder, "ImportEmployee", "ImportAttendance.xlsx");
            ResponseModal responseModal = new ResponseModal { meta = new MetaModal { Success = true, Message = "OK", ErrorCode = -1 }, data = null };
            string ex = System.IO.Path.GetExtension(excel_file_upload.FileName);
            string ContentType = excel_file_upload.ContentType;

            if (ContentType == "application/octet-stream" && ex.ToLower() == ".xlsx") //application/vnd.openxmlformats-officedocument.spreadsheetml.sheet
            {
                try
                {
                    excel_file_upload.SaveAs(PathExcel1);
                    responseModal.data = "ImportAttendance.xlsx";
                    return Json(responseModal);
                }
                catch (Exception e)
                {
                    responseModal.meta.ErrorCode = 11119;
                    responseModal.meta.Success = false;
                    responseModal.meta.Message = string.Format("{0} {1}", Lang.GeneralUI_ServerError, e.Message);
                    return Json(responseModal);
                }

            }
            else
            {
                responseModal.meta.ErrorCode = 11119;
                responseModal.meta.Success = false;
                responseModal.meta.Message = Lang.StandardImport_UnexpectFileType;
                return Json(responseModal);
            }
        }
    }
}