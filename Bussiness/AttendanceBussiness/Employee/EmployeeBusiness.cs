using AttendanceBussiness.DbFirst;
using Common;
using LanguageResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using static AttendanceBussiness.ShiftBusiness;

namespace AttendanceBussiness.EmployBusiness
{
    public partial class ApplyToDevice
    {
        [Required(ErrorMessageResourceName = "Employee_EmployeeId_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public string EmployeeId { get; set; }
        [Required(ErrorMessageResourceName = "DeviceUser_DeviceId_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public string DeviceId { get; set; }
        [Required]
        public int SearchMode { get; set; } = (int)DeviceEntryMode.INOUT;
    }

    public partial class ApplyDepartmentToDevice
    {
        [Required(ErrorMessageResourceName = "Employee_DepartmentId_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public string DepartmentId { get; set; }
        [Required(ErrorMessageResourceName = "DeviceUser_DeviceId_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public string DeviceId { get; set; }
        [Required]
        public int SearchMode { get; set; } = (int)DeviceEntryMode.INOUT;
    }

    public partial class DeviceUtility
    {
        /// <summary>
        /// Sychronize to Device user
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <param name="DeviceId"></param>
        /// <param name="SearchMode"></param>
        /// <param name="Host"> format http://www.abc.com or http://192.168.0.1</param>
        /// <returns></returns>
        public bool TerminalDeviceIdSync(string EmployeeId, string DeviceId, int SearchMode,string Host)
        {
            using (DataBaseContext dbContext = new DataBaseContext() )
            {
                Uri HostUri = new Uri(Host);
                try
                {
                    Employee employee = dbContext.Employee.Find(EmployeeId);
                    Device device = dbContext.Device.Find(DeviceId);
                    DeviceUser deviceUser = new DeviceUser();
                    List<UploadItem> uploadItems = dbContext.UploadItem.Where(s => s.TargetTalbeKeyId.Contains(EmployeeId)).OrderByDescending(s => s.OperatedDate).ToList();
                    if (uploadItems.Count > 0 && uploadItems.Count <= 1)
                    { 
                        string relateUrl = Common.PictureSuffix.ReturnSizePicUrl(employee.UserIcon, Common.PictureSize.s600X600);
                        string UserIconPositive_Path = new Uri(HostUri, relateUrl).LocalPath;
                        deviceUser.UserIconPositive = CommonBase.ImgToBase64String(UserIconPositive_Path);
                        deviceUser.UserIconPositiveIsUpdate = false;
                    }
                    else if (uploadItems.Count > 0 && uploadItems.Count <= 3)
                    {
                        string UserIconPositive_Path = Common.PictureSuffix.ReturnSizePicUrl(uploadItems.Take(1).First().Url, Common.PictureSize.s600X600);
                        string localPath1 = new Uri(HostUri, UserIconPositive_Path).LocalPath;
                        deviceUser.UserIconPositive = CommonBase.ImgToBase64String(localPath1);
                        deviceUser.UserIconPositiveIsUpdate = false;

                        string UserIconSide_Path2 = Common.PictureSuffix.ReturnSizePicUrl(uploadItems.Skip(1).First().Url, Common.PictureSize.s600X600);
                        string localPath2 = new Uri(HostUri, UserIconSide_Path2).LocalPath;
                        deviceUser.UserIconSide = CommonBase.ImgToBase64String(localPath2);
                        deviceUser.UserIconSideIsUpdate = false;

                        string UserIconTopView_Path3 = Common.PictureSuffix.ReturnSizePicUrl(uploadItems.Skip(2).First().Url, Common.PictureSize.s600X600);
                        string localPath3 = new Uri(HostUri, UserIconTopView_Path3).LocalPath;
                        deviceUser.UserIconTopView = CommonBase.ImgToBase64String(localPath3);
                        deviceUser.UserIconTopViewIsUpdate = false;
                    }

                    deviceUser.SearchMode = SearchMode;
                    deviceUser.Id = dbContext.GetTableIdentityID("DE", "DeviceUser", 4);
                    deviceUser.EmployeeId = employee.EmployeeId;
                    deviceUser.EmployName = employee.CnName;
                    deviceUser.DeviceId = device.DeviceId;
                    deviceUser.DeviceName = device.DeviceName;
                    deviceUser.DevidceUserProfileId = string.Empty;
                    deviceUser.UserId = employee.EmployeeId;
                    deviceUser.AccessCardId = employee.AccessCardId;
                    DateTime dt = DateTime.Now;
                    deviceUser.CreatedDate = dt;
                    deviceUser.UpdatedDate = dt;
                    deviceUser.CreatedIsCompleted = false;
                    var getUserDevice = dbContext.DeviceUser.Where(s => (s.EmployeeId.Contains(EmployeeId) || s.UserId.Contains(EmployeeId)) && s.DeviceId.Contains(DeviceId)).ToList();

                    if (getUserDevice.Count == 0)
                    {
                        dbContext.DeviceUser.Add(deviceUser);
                        dbContext.SaveChanges();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
                
        }
    }
}
