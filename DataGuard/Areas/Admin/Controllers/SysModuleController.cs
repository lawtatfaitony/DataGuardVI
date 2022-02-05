using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttApiViewModal;
using AttendanceBussiness.DbFirst;
using AttEnumCode;
using DataGuard.Context;
using LanguageResource;
using Newtonsoft.Json;

namespace DataGuard.Areas.Admin.Controllers
{
    public class SysModuleController : BaseController
    {
        [Authorize(Roles = "SystemAdmin,Admin,LRO,MainComOprerator")]
        [HttpGet]
        public ActionResult GetList()
        {
            try {
                using (DataBaseContext dataBaseContext = new DataBaseContext())
                {
                    string CurrentMainComId = WebCookie.MainComId;

                    var sysModuleList = from s in dbContext.SysModule.Where(c => c.MainComId == CurrentMainComId).Select(s => new { s.SysModuleId, s.SysModuleName, s.IpAddress, s.Port, s.SysModuleUrl, s.SiteId, s.SiteName, s.MainComId })
                                        select s; 
                   
                    var sysModuleListJson = JsonConvert.SerializeObject(sysModuleList, Formatting.Indented, new JsonSerializerSettings { ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver() });
                    List<AttApiViewModal.SysModule> sysModule = JsonConvert.DeserializeObject<List<AttApiViewModal.SysModule>>(sysModuleListJson);
                    
                    ResponseModalX responseModalX = new ResponseModalX();
                    responseModalX.data = sysModule;
                    return Json(responseModalX, JsonRequestBehavior.AllowGet);
                }
            }
            catch(Exception ex)
            {
                ResponseModalX responseModalX = new ResponseModalX { meta = new MetaModalX { Success = false,ErrorCode = (int)GeneralReturnCode.FAIL,Message= $"{Lang.GeneralUI_Fail} {ex.Message}" },data = null };
                return Json(responseModalX, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "SystemAdmin,Admin,LRO,MainComOprerator")]
        [HttpGet]
        public ActionResult GetDeviceList(string sysModuleId)
        {
            try
            {
                using (DataBaseContext dataBaseContext = new DataBaseContext())
                {
                    string CurrentMainComId = WebCookie.MainComId;

                    var deviceList = from s in dbContext.Device.Where(c => c.MainComId == CurrentMainComId&&c.SysModuleId.Contains(sysModuleId)).Select(s => new { s.DeviceId, s.DeviceName, s.SysModuleId,s.SiteId, s.SiteName, s.MainComId })
                                        select s;

                    var deviceListJson = JsonConvert.SerializeObject(deviceList, Formatting.Indented, new JsonSerializerSettings { ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver() });
                    List<AttApiViewModal.DeviceForSelect> deviceListObj = JsonConvert.DeserializeObject<List<AttApiViewModal.DeviceForSelect>>(deviceListJson);

                    ResponseModalX responseModalX = new ResponseModalX();
                    responseModalX.data = deviceListObj;
                    return Json(responseModalX, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ResponseModalX responseModalX = new ResponseModalX { meta = new MetaModalX { Success = false, ErrorCode = (int)GeneralReturnCode.FAIL, Message = $"{Lang.GeneralUI_Fail} {ex.Message}" }, data = null };
                return Json(responseModalX, JsonRequestBehavior.AllowGet);
            }

        }
    }
}